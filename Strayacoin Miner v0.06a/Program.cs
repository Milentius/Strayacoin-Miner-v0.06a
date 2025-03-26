using LibreHardwareMonitor.Hardware;



namespace Strayacoin_Miner_v0._06a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the AsciiTableDrawer
            AsciiTableDrawer atd = new AsciiTableDrawer(130,4,ConsoleColor.DarkGray,ConsoleColor.Cyan,TextAlignment.Center);
            // Initialize the FileBrowser
            //FileBrowser fb = new FileBrowser(atd);
            // Initialize the StrayacoinConfig
            MinerSettings ms = new MinerSettings();
            // Initialize the OutputManager
            OutputManager om = new OutputManager(3000);
            // Initialize the sm_lib
            sm_lib sml = new sm_lib(ms.CliExecutable);
            // Initialize the ohm_lib
            ohm_lib hardwareMonitor = new ohm_lib();
            // init the UI Renderer
            UI_Renderer uir = new UI_Renderer(atd);
            // Set the console window size
            Console.SetWindowSize(140, 34);

            InputManager im = new InputManager(uir);

            atd.WindowDrawer.DrawWindowContent_SingleRow("Strayacoin Miner v0.06a");
            atd.WindowDrawer.DrawWindowContent_doubleRow("line 1", "line 2");
            atd.WindowDrawer.DrawWindowContent_TripleRow("line 1", "line 2", "line 3");

            //// Define the tab functions
            //Action[] tabs = new Action[]
            //{
            //    UI_Renderer.Configuration.TabBrowser_Page1,
            //    UI_Renderer.Configuration.TabBrowser_Page2,
            //    UI_Renderer.Configuration.TabBrowser_Page3
            //};
            //
            //int currentTabIndex = 0;
            //string userInput = "Escape";
            //string keyPressed;
            //
            //// Display the initial tab
            //tabs[currentTabIndex]();
            //
            //while ((keyPressed = im.ListenForKeyPress()) != userInput)
            //{
            //    if (keyPressed == "Left" && currentTabIndex > 0)
            //    {
            //        currentTabIndex--;
            //        Console.Clear();
            //        tabs[currentTabIndex]();
            //    }
            //    else if (keyPressed == "Right" && currentTabIndex < tabs.Length - 1)
            //    {
            //        currentTabIndex++;
            //        Console.Clear();
            //        tabs[currentTabIndex]();
            //    }
            //}
            Console.ReadLine();

        }

        private static bool MinerInit(MinerSettings ms)
        {
            // Check if the setup is completed
            
            // if the SetupCompleted property is false, we should check that the user has not manually setup the miner
            if (ms.SetupCompleted == false)
            {
                //// Display the max cores available message
                //UI_Renderer.InitMessages.Init_MaxCoresAvailable();
                //
                //// Display the mining cores allowed message
                //UI_Renderer.InitMessages.Init_MiningCoresAllowed();
                //
                //// Display the wallet executable message
                //UI_Renderer.InitMessages.Init_WalletExecutable();
                //
                //// Display the CLI executable message
                //UI_Renderer.InitMessages.Init_CliExecutable();
                //
                //// Display the config file wallet message
                //UI_Renderer.InitMessages.Init_ConfigFile_Wallet();
                //
                //// Display the config file user message
                //UI_Renderer.InitMessages.Init_ConfigFile_User();
                
            }
            
            return ms.SetupCompleted;
        }
    }
}
