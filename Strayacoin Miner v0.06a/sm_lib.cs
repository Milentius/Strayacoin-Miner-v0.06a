using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Strayacoin_Miner_v0._06a
{
    public class sm_lib
    {

        private readonly string cliPath;

        /// <summary>
        /// Constructor
        /// </summary>
        public sm_lib(string cliPath)
        {
            this.cliPath = cliPath;
        }

        /// <summary>
        /// Execute a command using the Strayacoin CLI
        /// </summary>
        /// <returns>Returns an Indented JSON string</returns>
        public string ExecuteCommand(string arguments)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = cliPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                process.OutputDataReceived += (sender, args) => outputBuilder.AppendLine(args.Data);
                process.ErrorDataReceived += (sender, args) => errorBuilder.AppendLine(args.Data);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Error executing command: {errorBuilder.ToString()}");
                }

                return outputBuilder.ToString();
            }
        }

        /// <summary>
        /// Depreciated - Get the account associated with an address
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public string GetAccount(string address)
        {
            return ExecuteCommand($"getaccount \"{address}\"");
        }

        /// <summary>
        /// Get the blockchain information from the Strayacoin CLI
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public string GetBlockchainInfo()
        {
            return ExecuteCommand("getblockchaininfo");
        }

        /// <summary>
        /// Get the block count
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public int GetBlockCount()
        {
            var output = ExecuteCommand("getblockcount");
            return int.Parse(output.Trim());
        }

        /// <summary>
        /// Backup the wallet.dat file to a specified destination
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public string BackupWallet(string destination)
        {
            return ExecuteCommand($"backupwallet \"{destination}\"");
        }

        /// <summary>
        /// Encrypt the wallet with a passphrase to secure it
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public string EncryptWallet(string passphrase)
        {
            return ExecuteCommand($"encryptwallet \"{passphrase}\"");
        }

        /// <summary>
        /// Import a private key into the wallet from a file
        /// </summary>
        /// <returns>Returns JSON String</returns>
        public string ImportWallet(string filename)
        {
            return ExecuteCommand($"importwallet \"{filename}\"");
        }

        public string GetBalance(string account, int minconf = 1, bool includeWatchonly = false)
        {
            return ExecuteCommand($"getbalance \"{account}\" {minconf} {includeWatchonly.ToString().ToLower()}");
        }

        public string GetUnconfirmedBalance()
        {
            return ExecuteCommand("getunconfirmedbalance");
        }

        public string GetWalletInfo()
        {
            return ExecuteCommand("getwalletinfo");
        }

        public string ListAccounts(int minconf = 1, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listaccounts {minconf} {includeWatchonly.ToString().ToLower()}");
        }

        public string ListReceivedByAccount(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listreceivedbyaccount {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }


        public string ListReceivedByAddress(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listreceivedbyaddress {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }


        public string ListTransactions(string account, int count = 10, int skip = 0, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listtransactions \"{account}\" {count} {skip} {includeWatchonly.ToString().ToLower()}");
        }


        public string ListWallets()
        {
            return ExecuteCommand("listwallets");
        }

        public string Move(string fromAccount, string toAccount, decimal amount, int minconf = 1, string comment = "")
        {
            return ExecuteCommand($"move \"{fromAccount}\" \"{toAccount}\" {amount} {minconf} \"{comment}\"");
        }

        public string SendFrom(string fromAccount, string toAddress, decimal amount, int minconf = 1, string comment = "", string commentTo = "")
        {
            return ExecuteCommand($"sendfrom \"{fromAccount}\" \"{toAddress}\" {amount} {minconf} \"{comment}\" \"{commentTo}\"");
        }

        public string SendToAddress(string address, decimal amount, string comment = "", string commentTo = "", bool subtractFeeFromAmount = false, bool replaceable = false, int confTarget = 6, string estimateMode = "UNSET")
        {
            return ExecuteCommand($"sendtoaddress \"{address}\" {amount} \"{comment}\" \"{commentTo}\" {subtractFeeFromAmount.ToString().ToLower()} {replaceable.ToString().ToLower()} {confTarget} \"{estimateMode}\"");
        }

        public string SignMessage(string address, string message)
        {
            return ExecuteCommand($"signmessage \"{address}\" \"{message}\"");
        }




        public string GetConnectionCount()
        {
            return ExecuteCommand("getconnectioncount");
        }



        public string GetNetTotals()
        {
            return ExecuteCommand("getnettotals");
        }



        public string GetNetworkInfo()
        {
            return ExecuteCommand("getnetworkinfo");
        }



        public string GetPeerInfo()
        {
            return ExecuteCommand("getpeerinfo");
        }




        public string GetMiningInfo()
        {
            return ExecuteCommand("getmininginfo");
        }


        public string GetNetworkHashPS(int nblocks = 120, int height = -1)
        {
            return ExecuteCommand($"getnetworkhashps {nblocks} {height}");
        }


        public string Generate(int nblocks, int maxtries = 1000000)
        {
            return ExecuteCommand($"generate {nblocks} {maxtries}");
        }


        public string GenerateToAddress(int nblocks, string address, int maxtries = 1000000)
        {
            return ExecuteCommand($"generatetoaddress {nblocks} \"{address}\" {maxtries}");
        }


        public string GetInfo()
        {
            return ExecuteCommand("getinfo");
        }


        public string Uptime()
        {
            return ExecuteCommand("uptime");
        }


        public string GetNewAddress(string account = "")
        {
            return ExecuteCommand($"getnewaddress \"{account}\"");
        }

    

    }
}