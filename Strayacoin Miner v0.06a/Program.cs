using Ascii_Table_Drawer;
using File_Browser;


namespace Strayacoin_Miner_v0._06a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsciiTableDrawer atd = new AsciiTableDrawer();
            //FileBrowser fb = new FileBrowser(atd);
            //StrayacoinConfig sc = new StrayacoinConfig();
            //OutputManager om = new OutputManager(3000);
            //sm_lib sml = new sm_lib("path/to/cli");
            
            atd.Padding = 2;
            
            Console.SetWindowSize(150, 50);


            UI_Renderer uir = new UI_Renderer(atd);
            uir.RenderUI();
            Console.ReadLine();




            //Console.WindowWidth = 160; // Set the width to 120 characters (adjust as needed)
            // Console.WindowHeight = 160; // Set the width to 120 characters (adjust as needed)

            // Create sample data for DataPackage
            //DataPackage dataPackage = new DataPackage
            //{
            //    // Mining Information
            //    CurrentHashRate = 1234.56,
            //    TotalHashesMined = 78901234,
            //    ActiveMiningCores = 4,
            //    MiningPoolStatus = "Connected",
            //    MiningDifficulty = 1.234,
            //    AcceptedShares = 123,
            //    RejectedShares = 4,
            //
            //    // Wallet Information
            //    WalletBalance = 12.34m,
            //    UnconfirmedBalance = 1.23m,
            //    RecentTransactions = new List<string> { "Tx1", "Tx2", "Tx3" },
            //    WalletAddress = "1A2b3C4d5E6f7G8h9I0j",
            //    IsWalletEncrypted = true,
            //
            //    // System Information
            //    CpuUsage = 45.6,
            //    MemoryUsage = 67.8,
            //    HardwareTemperature = 70.5,
            //    FanSpeed = 1200,
            //    Uptime = TimeSpan.FromHours(5),
            //
            //    // Network Information
            //    ConnectionStatus = "Online",
            //    ConnectedPeers = 8,
            //    NetworkHashRate = 123456.78,
            //    DataSent = 123456,
            //    DataReceived = 654321,
            //
            //    // Configuration Information
            //    ConfigFilePath = "path/to/config",
            //    WalletExecutablePath = "path/to/wallet",
            //    UIMode = 0,
            //    TextColor = ConsoleColor.White,
            //    BackgroundColor = ConsoleColor.Black,
            //    RefreshRate = 1000
            //};




            Console.ReadLine();
        }
    }
}
