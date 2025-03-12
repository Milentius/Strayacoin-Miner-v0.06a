using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    public interface ISettingEvaluator<T>
    {
        T Evaluate(object propertyValue);
    }

    public class WalletExecutableEvaluator : ISettingEvaluator<bool>
    {
        public bool Evaluate(object propertyValue)
        {
            //return !string.IsNullOrEmpty(propertyValue as string) && propertyValue.ToString().Contains("strayacoin-qt");
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin-qt"))
            {
                string filePath = propertyValue as string;
                string extension = Path.GetExtension(filePath);
                if (extension == ".exe")
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    public class CliExecutableEvaluator : ISettingEvaluator<bool>
    {
        public bool Evaluate(object propertyValue)
        {
            //return !string.IsNullOrEmpty(propertyValue as string) && propertyValue.ToString().Contains("strayacoin-cli");
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin-cli"))
            {
                string filePath = propertyValue as string;
                string extension = Path.GetExtension(filePath);
                if (extension == ".exe")
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    public class ConfigFileWalletEvaluator : ISettingEvaluator<bool>
    {
        private const string DefaultRpcUsername = "yourusername";
        private const string DefaultRpcPassword = "whateveryouwant";

        public bool Evaluate(object propertyValue)
        {
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin.conf"))
            {
                // propertyValue is the path to the config file
                foreach (string line in File.ReadAllLines(propertyValue.ToString()))
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

        public bool Evaluate(object propertyValue)
        {
            if (propertyValue != null && propertyValue.ToString().Contains("strayacoin.conf"))
            {
                // propertyValue is the path to the config file
                foreach (string line in File.ReadAllLines(propertyValue.ToString()))
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

        public bool Evaluate(object propertyValue)
        {
            string address = propertyValue as string;
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }

            // Decode the address using Base58Check
            if (!Base58Check.DecodeBase58Check(address, out byte[] decoded))
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

    public class MiningCoresEvaluator : ISettingEvaluator<bool>
    {
        public bool Evaluate(object propertyValue)
        {
            
            if (propertyValue == null || propertyValue as string == "0")
            {
                if (int.TryParse(propertyValue.ToString(), out int cores))
                {
                    // Check if the number of cores is greater than 0
                    if (cores >= 2)
                    {

                    }
                        return true;
                }
                return false;
            }
            else
            {
                
            }
            return !string.IsNullOrEmpty(propertyValue as string);
        }
    }
}
