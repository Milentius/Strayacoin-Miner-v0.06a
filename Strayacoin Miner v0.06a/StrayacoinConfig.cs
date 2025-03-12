using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Strayacoin_Miner_v0._06a
{
    public class StrayacoinConfig
    {
        /// <summary>
        /// DeviceID - [String] - [Identifier for the device]
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// MaxAvailableCores - [int] - [Maximum number of cores available on the device]
        /// </summary>
        public int MaxAvailableCores { get; set; }

        /// <summary>
        /// MaxCoresAllowed - [int] - [Maximum number of cores allowed to be used by the miner, this connot be changed while running]
        /// </summary>
        public int MaxCoresAllowed { get; set; }

        /// <summary>
        /// WalletExecutable - [String] - [Path to the Wallet Executable]
        /// </summary>
        public string WalletExecutable { get; set; }

        /// <summary>
        /// CliExecutable - [String] - [Path to the CommandLine Interface Executable]
        /// </summary>
        public string CliExecutable { get; set; }

        /// <summary>
        /// ConfigFile_Wallet - [String] - [Path to the Wallet Configuration File]
        /// </summary>
        public string ConfigFile_Wallet { get; set; }

        /// <summary>
        /// ConfigFile_User - [String] - [Path to the User Configuration File]
        /// </summary>
        public string ConfigFile_User { get; set; }
        
        /// <summary>
        /// ConfigTest - [int] - [Test Configuration File]
        /// [0 = Success]
        /// [1 = Mismatch Username]
        /// [2 = Mismatch Password]
        /// </summary>
        public int ConfigTest { get; set; }

        /// <summary>
        /// PaymentAddress
        /// string - Wallet Address to receive payments from mining
        /// </summary>
        public string PaymentAddress { get; set; }

        // Mining Settings                                          
        /// <summary>
        /// MiningCores - [int] - [Number of cores to be used for mining, this can be changed while mining]
        /// </summary>
        public int MiningCores { get; set; }

        /// <summary>
        /// Mining_PoolURL - [String] - [URL of the Mining Pool]
        /// </summary>
        public string Mining_PoolURL { get; set; }

        /// <summary>
        /// Mining_PoolUsername - [String] - [Username for the Mining Pool]
        /// </summary>
        public string Mining_PoolUsername { get; set; }

        /// <summary>
        /// Mining_PoolPassword - [String] - [Password for the Mining Pool]
        public string Mining_PoolPassword { get; set; }

        /// <summary>
        /// Mining_Intensity - [String] - [Not Yet Implemented - Mining Intensity]
        /// </summary>
        public string Mining_Intensity { get; set; }

        /// <summary>
        /// Mining_Target - [String] - [Not Yet Implemented - Mining Target]
        /// </summary>
        public string Mining_Target { get; set; }

        /// <summary>
        /// ProxyAddress - [String] - [Not Yet Implemented - Address to use for a Proxy]
        /// </summary>
        public string ProxyAddress { get; set; }                    // Proxy Address

        /// <summary>
        /// ProxyPort - [int] - [Not Yet Implemented - Port to use for a Proxy]
        /// </summary>
        public int ProxyPort { get; set; }                          // Proxy Port

        /// <summary>
        /// UseCoreBouncing - [bool] - [Use Core Bouncing to spread load]
        /// </summary>
        public bool UseCoreBouncing { get; set; } = true;

        /// <summary>
        /// CoreBounceInterval - [int] - [Interval for often to Bounce to a new Core]
        /// [0 = System Managed]
        /// [1 = Every Block Mined]
        /// [>2 = Number of Blocks to mine before bouncing]
        /// </summary>
        public int CoreBounceInterval { get; set; } = 0;            // Interval for Core Bouncing (how often to bounce, 0 = System Managed)

        /// <summary>
        /// UnbouncedCores - [int array] - [Cores to be excluded from Core Bouncing]
        /// </summary>
        public int[] UnbouncedCores { get; set; }                   // Cores to be excluded from Core Bouncing

        /// <summary>
        /// MaxTemperatureLimit - [int] - [Max Temperature Limit before mining is halted]
        /// </summary>
        public int MaxTemperatureLimit { get; set; } = 90;          // Max Temperature Limit before mining is halted

        /// <summary>
        /// LogFilePath - [String] - [Path to the Log File]
        /// </summary>
        public string LogFilePath { get; set; }

        /// <summary>
        /// LogLevel - [int] - [Log Level (0 = None, 1 = Errors, 2 = Warnings, 3 = Info, 4 = Debug)]
        /// [0 = None]
        /// [1 = Errors Only]
        /// [2 = Errors & Warnings]
        /// [3 = Errors, Warnings & Info]
        /// [4 = Errors, Warnings, Info & Debug]
        /// </summary>
        public int LogLevel { get; set; } = 3;

        /// <summary>
        /// DebugMonitorInterval - [int] - [Interval for often to post Debug info]
        /// </summary>
        public int DebugMonitorInterval { get; set; } = 10;         // Interval for Debug Monitor (how often to post to the log file)

        /// <summary>
        /// EncryptWallet - [bool] - [Encrypt the Wallet]
        /// </summary>
        public bool EncryptWallet { get; set; } = false;

        /// <summary>
        /// EncryptionPassphrase - [String] - [Passphrase for Wallet Encryption]
        /// </summary>
        public string EncryptionPassphrase { get; set; }            // Passphrase for Wallet Encryption

        /// <summary>
        /// UIMode - [int] - [User Interface Mode]
        /// </summary>
        public int UIMode { get; set; } = 0;

        /// <summary>
        /// TextColor - [ConsoleColor] - [Text Color for the Output]
        /// </summary>
        public ConsoleColor TextColor { get; set; }

        /// <summary>
        /// BackgroundColor - [ConsoleColor] - [Background Color for the Output]
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }           // Default Background Color

        /// <summary>
        /// OutputRefreshRate - [int] - [How often to update the Console with new information in milliseconds]
        /// </summary>
        public int OutputRefreshRate { get; set; } = 100;           // Refresh Rate for the Console Output (in milliseconds)

       
        private const string MinerSettingsFileName = "MinerSettings.json";


        /// <summary>
        /// CheckJson - [bool] - [Check if the JSON file exists, if it does not it create one, returns 'false' if one is created]
        /// </summary>
        public bool CheckJson()
        {
            string settingsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Miner Settings");
            string settingsFilePath = Path.Combine(settingsDirectory, MinerSettingsFileName);

            if (!Directory.Exists(settingsDirectory))
            {
                Directory.CreateDirectory(settingsDirectory);
            }

            if (!File.Exists(settingsFilePath))
            {
                SaveSettings(settingsFilePath);
                return false;
            }
            else
            {
                LoadSettings(settingsFilePath);
                return true;
            }
        }

        public void SaveSettings(string filePath = null)
        {
            if (filePath == null)
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Miner Settings", MinerSettingsFileName);
            }
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadSettings(string filePath = null)
        {
            if (filePath == null)
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Miner Settings", MinerSettingsFileName);
            }
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                JsonConvert.PopulateObject(json, this);
            }
        }

        public bool EvaluateSettings(string minerSettings)
        {
            string settingsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Miner Settings");
            string settingsFilePath = Path.Combine(settingsDirectory, MinerSettingsFileName);

            if (!File.Exists(settingsFilePath))
            {
                return false;
            }

            StrayacoinConfig settings = JsonConvert.DeserializeObject<StrayacoinConfig>(minerSettings);
            SettingsEvaluator evaluator = new SettingsEvaluator();

            foreach (var property in settings.GetType().GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(settings);

                // Use the generic Evaluate method
                var result = evaluator.Evaluate<object>(propertyName, propertyValue);

                // Check if the result is a boolean and if it's false
                if (result is bool boolResult && !boolResult)
                {
                    return false;
                }

                // Add additional checks for other types if needed
            }

            return true;
        }
    }
}
