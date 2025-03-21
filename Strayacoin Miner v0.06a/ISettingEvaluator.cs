using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;

namespace Strayacoin_Miner_v0._06a
{
    public interface ISettingEvaluator<T>
    {
        Task<T> EvaluateAsync(object propertyValue);
    }

    public class SetupCompleted : ISettingEvaluator<bool>
    {
        public Task<bool> EvaluateAsync(object propertyValue)
        {
            bool result = propertyValue != null && (bool)propertyValue == true;
            return Task.FromResult(result);
        }
    }

    public class WalletInstallDirectoryEvaluator : ISettingEvaluator<bool>
    {
        public async Task<bool> EvaluateAsync(object propertyValue)
        {
            if (propertyValue != null && propertyValue is string)
            {
                string path = Path.Combine(propertyValue.ToString(), "strayacoin-qt.exe");
                return await Task.Run(() => File.Exists(path));
            }

            return false;
        }
    }

    public class WalletExecutableEvaluator : ISettingEvaluator<bool>
    {
        public Task<bool> EvaluateAsync(object propertyValue)
        {
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin-qt"))
            {
                string filePath = propertyValue as string;
                string extension = Path.GetExtension(filePath);
                return Task.FromResult(extension == ".exe");
            }
            return Task.FromResult(false);
        }
    }

    public class CliExecutableEvaluator : ISettingEvaluator<bool>
    {
        public Task<bool> EvaluateAsync(object propertyValue)
        {
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin-cli"))
            {
                string filePath = propertyValue as string;
                string extension = Path.GetExtension(filePath);
                return Task.FromResult(extension == ".exe");
            }
            return Task.FromResult(false);
        }
    }

    public class ConfigFileWalletEvaluator : ISettingEvaluator<bool>
    {
        private const string DefaultRpcUsername = "yourusername";
        private const string DefaultRpcPassword = "whateveryouwant";

        public async Task<bool> EvaluateAsync(object propertyValue)
        {
            string filename = propertyValue as string;
            if (propertyValue != null && filename.Contains("strayacoin.conf"))
            {
                // propertyValue is the path to the config file
                string[] lines = await File.ReadAllLinesAsync(filename);
                foreach (string line in lines)
                {
                    if (line.Contains("rpcusername=" + DefaultRpcUsername) || line.Contains("rpcpassword=" + DefaultRpcPassword))
                    {
                        return false; // Default username or password found
                    }
                }
                return true; // File exists and default values are not found
            }

            // the propertyValue is null or does not contain the config file path
            return false;
        }
    }

    public class ConfigFileAppDataEvaluator : ISettingEvaluator<bool>
    {
        private const string DefaultRpcUsername = "yourusername";
        private const string DefaultRpcPassword = "whateveryouwant";

        public async Task<bool> EvaluateAsync(object propertyValue)
        {
            string filename = propertyValue as string;
            if (propertyValue != null && filename.Contains("strayacoin.conf"))
            {
                // propertyValue is the path to the config file
                string[] lines = await File.ReadAllLinesAsync(filename);
                foreach (string line in lines)
                {
                    if (line.Contains("rpcusername=" + DefaultRpcUsername) || line.Contains("rpcpassword=" + DefaultRpcPassword))
                    {
                        return false; // Default username or password found
                    }
                }
                return true; // File exists and default values are not found
            }

            // the propertyValue is null or does not contain the config file path
            return false;
        }
    }

    public class PaymentAddressEvaluator : ISettingEvaluator<bool>
    {
        private const int StrayacoinAddressLength = 25; // 1 byte version + 20 bytes hash + 4 bytes checksum
        private static readonly byte[] ValidPrefixes = { 0x00, 0x6F }; // Example: 0x00 for mainnet, 0x6F for testnet

        public async Task<bool> EvaluateAsync(object propertyValue)
        {
            string address = propertyValue as string;
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }

            byte[] decoded = null;

            // Decode the address using Base58Check
            bool isValid = await Task.Run(() => Base58Check.DecodeBase58Check(address, out decoded));
            if (!isValid)
            {
                return false; // Invalid Base58Check encoding
            }

            // Check the length of the decoded address
            if (decoded.Length != StrayacoinAddressLength)
            {
                return false; // Invalid length
            }

            // Check for valid address prefixes
            byte prefix = decoded[0];
            if (!ValidPrefixes.Contains(prefix))
            {
                return false; // Invalid prefix
            }

            return true; // Address is valid
        }
    }

    /// <summary>
    /// Used to evaluate the cores used for mining, overridden by CoreBouncing if enabled, this setting allows windows to manage cores
    /// </summary>
    public class MiningCoresEvaluator : ISettingEvaluator<int>
    {
        public async Task<int> EvaluateAsync(object propertyValue)
        {
            int miningCores = (int)propertyValue;
            if (propertyValue != null && miningCores >= 1)
            {
                if (int.TryParse(propertyValue.ToString(), out int cores))
                {
                    // we need to make sure we keep at min 1 core, where possible 2 cores available, 1 for the system and 1 for the UI
                    int[] info = await GetProcessorInformationFromWAPIAsync();
                    int physicalCores = info[0];
                    int logicalCores = info[1];
                    if (logicalCores > physicalCores)
                    {
                        if (physicalCores - 2 >= 1)
                        {
                            return physicalCores - 2;
                        }
                        return physicalCores / 2;
                    }
                    if (logicalCores <= physicalCores)
                    {
                        if (physicalCores >= 4)
                        {
                            return physicalCores - 2;
                        }
                        else if (physicalCores / 2 >= 1)
                        {
                            return physicalCores / 2;
                        }
                    }
                    return 1;
                }
                return 1;
            }

            return 1;
        }

        static async Task<int[]> GetProcessorInformationFromWAPIAsync()
        {
            int physicalCores = 0, logicalCores = 0;

            await Task.Run(() => GetCoreCounts(ref physicalCores, ref logicalCores));

            Console.WriteLine($"Logical Cores (Threads): {logicalCores}");
            Console.WriteLine($"Physical Cores: {physicalCores}");
            Console.WriteLine($"Hyperthreading Enabled: {logicalCores > physicalCores}");
            return new[] { physicalCores, logicalCores };
        }

        static void GetCoreCounts(ref int physicalCores, ref int logicalCores)
        {
            int returnLength = 0;
            GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorCore, IntPtr.Zero, ref returnLength);

            IntPtr ptr = Marshal.AllocHGlobal(returnLength);
            if (GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorCore, ptr, ref returnLength))
            {
                IntPtr current = ptr;
                while (returnLength > 0)
                {
                    PROCESSOR_RELATIONSHIP info = Marshal.PtrToStructure<PROCESSOR_RELATIONSHIP>(current);
                    physicalCores++; // Each entry represents one physical core

                    // Count the number of logical processors in this physical core
                    logicalCores += CountBits(info.GroupMask.Mask);

                    int size = Marshal.SizeOf<PROCESSOR_RELATIONSHIP>();
                    current = IntPtr.Add(current, size);
                    returnLength -= size;
                }
            }
            Marshal.FreeHGlobal(ptr);
        }

        static int CountBits(ulong bitmask)
        {
            int count = 0;
            while (bitmask > 0)
            {
                count += (int)(bitmask & 1);
                bitmask >>= 1;
            }
            return count;
        }

        private const int ERROR_INSUFFICIENT_BUFFER = 122;

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP relationship, IntPtr buffer, ref int returnLength);

        private enum LOGICAL_PROCESSOR_RELATIONSHIP
        {
            RelationProcessorCore = 0,
            RelationNumaNode,
            RelationCache,
            RelationProcessorPackage,
            RelationGroup,
            RelationAll = 0xFFFF
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESSOR_RELATIONSHIP
        {
            public byte Flags;
            public byte EfficiencyClass;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] Reserved;
            public GROUP_AFFINITY GroupMask;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct GROUP_AFFINITY
        {
            public ulong Mask;
            public ushort Group;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] Reserved;
        }
    }

    /// <summary>
    /// unused at the moment, kingsley may never make us a mining pool, SIGH! ♥
    /// </summary>
    public class Use_Mining_Pool : ISettingEvaluator<string>
    {
        public Task<string> EvaluateAsync(object propertyValue)
        {
            return Task.FromResult("Kingsley Broke This Setting");
        }
    }

    public class UseCoreBouncing : ISettingEvaluator<bool>
    {
        public Task<bool> EvaluateAsync(object propertyValue)
        {
            bool result = propertyValue != null && (bool)propertyValue == true;
            return Task.FromResult(result);
        }
    }

    public class CoreBounceInterval : ISettingEvaluator<int>
    {
        public Task<int> EvaluateAsync(object propertyValue)
        {
            if (propertyValue is int interval && interval >= 0)
            {
                return Task.FromResult(interval);
            }
            return Task.FromResult(0); // Default to system managed if invalid
        }
    }

    public class UnbouncedCores : ISettingEvaluator<int[]>
    {
        public Task<int[]> EvaluateAsync(object propertyValue)
        {
            int[] unbouncedCores = propertyValue as int[];

            if (unbouncedCores != null && unbouncedCores.Length > 0)
            {
                return Task.FromResult(unbouncedCores);
            }

            return Task.FromResult(new int[] { });
        }
    }

    public class TemperatureMax : ISettingEvaluator<int>
    {
        public Task<int> EvaluateAsync(object propertyValue)
        {
            Computer computer = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true
            };
            computer.Open();
            foreach(Hardware hardwareItem in computer.Hardware)
            {
                hardwareItem.Update(); 
                if(hardwareItem.HardwareType == HardwareType.Cpu)
                {
                    if(hardwareItem.Sensors.Length > 0)
                    {
                        foreach (ISensor sensor in hardwareItem.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                return Task.FromResult((int)sensor.Value);
                            }
                        }
                    }
                }
            }

            return Task.FromResult(85);
        }
    }
}
