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

        public sm_lib(string cliPath)
        {
            this.cliPath = cliPath;
        }

        public async Task<string> ExecuteCommandAsync(string arguments)
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
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Error executing command: {errorBuilder.ToString()}");
                }

                return outputBuilder.ToString();
            }
        }

        public async Task<string> GetAccountAsync(string address)
        {
            return await ExecuteCommandAsync($"getaccount \"{address}\"");
        }

        public async Task<string> GetBlockchainInfoAsync()
        {
            return await ExecuteCommandAsync("getblockchaininfo");
        }

        public async Task<int> GetBlockCountAsync()
        {
            var output = await ExecuteCommandAsync("getblockcount");
            return int.Parse(output.Trim());
        }

        public async Task<string> BackupWalletAsync(string destination)
        {
            return await ExecuteCommandAsync($"backupwallet \"{destination}\"");
        }

        public async Task<string> EncryptWalletAsync(string passphrase)
        {
            return await ExecuteCommandAsync($"encryptwallet \"{passphrase}\"");
        }

        public async Task<string> ImportWalletAsync(string filename)
        {
            return await ExecuteCommandAsync($"importwallet \"{filename}\"");
        }

        public async Task<string> GetBalanceAsync(string account, int minconf = 1, bool includeWatchonly = false)
        {
            return await ExecuteCommandAsync($"getbalance \"{account}\" {minconf} {includeWatchonly.ToString().ToLower()}");
        }

        public async Task<string> GetUnconfirmedBalanceAsync()
        {
            return await ExecuteCommandAsync("getunconfirmedbalance");
        }

        public async Task<string> GetWalletInfoAsync()
        {
            return await ExecuteCommandAsync("getwalletinfo");
        }

        public async Task<string> ListAccountsAsync(int minconf = 1, bool includeWatchonly = false)
        {
            return await ExecuteCommandAsync($"listaccounts {minconf} {includeWatchonly.ToString().ToLower()}");
        }

        public async Task<string> ListReceivedByAccountAsync(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return await ExecuteCommandAsync($"listreceivedbyaccount {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }

        public async Task<string> ListReceivedByAddressAsync(int minconf = 1, bool includeEmpty = false, bool includeWatchonly = false)
        {
            return await ExecuteCommandAsync($"listreceivedbyaddress {minconf} {includeEmpty.ToString().ToLower()} {includeWatchonly.ToString().ToLower()}");
        }

        public async Task<string> ListTransactionsAsync(string account, int count = 10, int skip = 0, bool includeWatchonly = false)
        {
            return await ExecuteCommandAsync($"listtransactions \"{account}\" {count} {skip} {includeWatchonly.ToString().ToLower()}");
        }

        public async Task<string> ListWalletsAsync()
        {
            return await ExecuteCommandAsync("listwallets");
        }

        public async Task<string> MoveAsync(string fromAccount, string toAccount, decimal amount, int minconf = 1, string comment = "")
        {
            return await ExecuteCommandAsync($"move \"{fromAccount}\" \"{toAccount}\" {amount} {minconf} \"{comment}\"");
        }

        public async Task<string> SendFromAsync(string fromAccount, string toAddress, decimal amount, int minconf = 1, string comment = "", string commentTo = "")
        {
            return await ExecuteCommandAsync($"sendfrom \"{fromAccount}\" \"{toAddress}\" {amount} {minconf} \"{comment}\" \"{commentTo}\"");
        }

        public async Task<string> SendToAddressAsync(string address, decimal amount, string comment = "", string commentTo = "", bool subtractFeeFromAmount = false, bool replaceable = false, int confTarget = 6, string estimateMode = "UNSET")
        {
            return await ExecuteCommandAsync($"sendtoaddress \"{address}\" {amount} \"{comment}\" \"{commentTo}\" {subtractFeeFromAmount.ToString().ToLower()} {replaceable.ToString().ToLower()} {confTarget} \"{estimateMode}\"");
        }

        public async Task<string> SignMessageAsync(string address, string message)
        {
            return await ExecuteCommandAsync($"signmessage \"{address}\" \"{message}\"");
        }

        public async Task<string> GetConnectionCountAsync()
        {
            return await ExecuteCommandAsync("getconnectioncount");
        }

        public async Task<string> GetNetTotalsAsync()
        {
            return await ExecuteCommandAsync("getnettotals");
        }

        public async Task<string> GetNetworkInfoAsync()
        {
            return await ExecuteCommandAsync("getnetworkinfo");
        }

        public async Task<string> GetPeerInfoAsync()
        {
            return await ExecuteCommandAsync("getpeerinfo");
        }

        public async Task<string> GetMiningInfoAsync()
        {
            return await ExecuteCommandAsync("getmininginfo");
        }

        public async Task<string> GetNetworkHashPSAsync(int nblocks = 120, int height = -1)
        {
            return await ExecuteCommandAsync($"getnetworkhashps {nblocks} {height}");
        }

        public async Task<string> GenerateAsync(int nblocks, int maxtries = 1000000)
        {
            return await ExecuteCommandAsync($"generate {nblocks} {maxtries}");
        }

        public async Task<string> GenerateToAddressAsync(int nblocks, string address, int maxtries = 1000000)
        {
            return await ExecuteCommandAsync($"generatetoaddress {nblocks} \"{address}\" {maxtries}");
        }

        public async Task<string> GetInfoAsync()
        {
            return await ExecuteCommandAsync("getinfo");
        }

        public async Task<string> UptimeAsync()
        {
            return await ExecuteCommandAsync("uptime");
        }

        public async Task<string> GetNewAddressAsync(string account = "")
        {
            return await ExecuteCommandAsync($"getnewaddress \"{account}\"");
        }
    }
}