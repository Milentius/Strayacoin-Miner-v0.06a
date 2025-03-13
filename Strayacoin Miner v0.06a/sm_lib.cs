using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
        /// Executes a command using the Strayacoin CLI and returns the output as a JSON string.
        /// </summary>
        /// <param name="arguments">The arguments to pass to the Strayacoin CLI command.</param>
        /// <returns>A JSON string containing the output of the executed command.</returns>
        /// <exception cref="Exception">Thrown when the command execution fails.</exception>
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
        /// Retrieves detailed information about the blockchain from the Strayacoin CLI.
        /// </summary>
        /// <returns>A JSON string containing detailed information about the blockchain.</returns>
        public string GetBlockchainInfo()
        {
            return ExecuteCommand("getblockchaininfo");
        }

        /// <summary>
        /// Retrieves the current block count from the Strayacoin CLI.
        /// </summary>
        /// <returns>An integer representing the current block count.</returns>
        public int GetBlockCount()
        {
            var output = ExecuteCommand("getblockcount");
            return int.Parse(output.Trim());
        }

        /// <summary>
        /// Backs up the wallet.dat file to a specified destination.
        /// </summary>
        /// <param name="destination">The destination path where the wallet.dat file will be backed up.</param>
        /// <returns>A JSON string indicating the result of the backup operation.</returns>
        public string BackupWallet(string destination)
        {
            return ExecuteCommand($"backupwallet \"{destination}\"");
        }

        /// <summary>
        /// Encrypts the wallet with a passphrase to secure it.
        /// </summary>
        /// <param name="passphrase">The passphrase to use for encrypting the wallet.</param>
        /// <returns>A JSON string indicating the result of the encryption operation.</returns>
        public string EncryptWallet(string passphrase)
        {
            return ExecuteCommand($"encryptwallet \"{passphrase}\"");
        }

        /// <summary>
        /// Imports a private key into the wallet from a file.
        /// </summary>
        /// <param name="filename">The path to the file containing the private key to be imported.</param>
        /// <returns>A JSON string indicating the result of the import operation.</returns>
        public string ImportWallet(string filename)
        {
            return ExecuteCommand($"importwallet \"{filename}\"");
        }

        /// <summary>
        /// Get the balance of an account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="minconf"></param>
        /// <param name="includeWatchonly"></param>
        /// <returns>Returns JSON String</returns>
        public string GetBalance(string account, int minconf = 1, bool includeWatchonly = false)
        {
            return ExecuteCommand($"getbalance \"{account}\" {minconf} {includeWatchonly.ToString().ToLower()}");
        }


        /// <summary>
        /// Retrieves the unconfirmed balance of the wallet from the Strayacoin CLI.
        /// </summary>
        /// <returns>A JSON string containing the unconfirmed balance of the wallet.</returns>
        public string GetUnconfirmedBalance()
        {
            return ExecuteCommand("getunconfirmedbalance");
        }

        /// <summary>
        /// Retrieves detailed information about the local running wallet from the Strayacoin CLI.
        /// </summary>
        /// <returns>A JSON string containing detailed information about the wallet.</returns>
        public string GetWalletInfo()
        {
            return ExecuteCommand("getwalletinfo");
        }


        /// <summary>
        /// Retrives a detailed list of all accounts in the local wallet
        /// </summary>
        /// <param name="minconf"></param>
        /// <param name="includeWatchonly"></param>
        /// <returns></returns>
        public string ListAccounts(int minconf = 1, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listaccounts {minconf} {includeWatchonly.ToString().ToLower()}");
        }

        /// <summary>
        /// Lists the balance of all accounts in the local wallet sorted by the account name.
        /// </summary>
        /// <param name="minconf"></param>
        /// <param name="includeEmpty"></param>
        /// <param name="includeWatchonly"></param>
        /// <returns></returns>
        public string ListReceivedByAccount(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listreceivedbyaccount {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }

        /// <summary>
        /// Lists the balance of all addresses in the local wallet sorted by the address of the account.
        /// </summary>
        /// <param name="minconf"></param>
        /// <param name="includeEmpty"></param>
        /// <param name="includeWatchonly"></param>
        /// <returns></returns>
        public string ListReceivedByAddress(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listreceivedbyaddress {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }

        /// <summary>
        /// Returns up to 'count' most recent transactions skipping the first 'skip' transactions for account 'account'.
        /// </summary>
        /// <param name="account">The account name. Should be "*".</param>
        /// <param name="count">The number of transactions to return (default is 10).</param>
        /// <param name="skip">The number of transactions to skip (default is 0).</param>
        /// <param name="includeWatchonly">Whether to include transactions to watch-only addresses (default is false).</param>
        /// <returns>A JSON string containing the list of transactions.</returns>
        /// <returns></returns>
        public string ListTransactions(string account, int count = 10, int skip = 0, bool includeWatchonly = false)
        {
            return ExecuteCommand($"listtransactions \"{account}\" {count} {skip} {includeWatchonly.ToString().ToLower()}");
        }

        /// <summary>
        /// Lists all wallets in the wallet directory.
        /// </summary>
        /// <returns></returns>
        public string ListWallets()
        {
            return ExecuteCommand("listwallets");
        }

        /// <summary>
        /// Moves a specified amount from one account to another.
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="amount"></param>
        /// <param name="minconf"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string Move(string fromAccount, string toAccount, decimal amount, int minconf = 1, string comment = "")
        {
            return ExecuteCommand($"move \"{fromAccount}\" \"{toAccount}\" {amount} {minconf} \"{comment}\"");
        }

        /// <summary>
        /// Sends a specified amount from one account to another.
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="minconf"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public string SendFrom(string fromAccount, string toAddress, decimal amount, int minconf = 1, string comment = "", string commentTo = "")
        {
            return ExecuteCommand($"sendfrom \"{fromAccount}\" \"{toAddress}\" {amount} {minconf} \"{comment}\" \"{commentTo}\"");
        }

        /// <summary>
        /// Sends a specified amount to a specified address.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="subtractFeeFromAmount"></param>
        /// <param name="replaceable"></param>
        /// <param name="confTarget"></param>
        /// <param name="estimateMode"></param>
        /// <returns></returns>
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