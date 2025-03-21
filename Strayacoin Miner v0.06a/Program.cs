using Ascii_Table_Drawer;
using File_Browser;
using LibreHardwareMonitor.Hardware;


namespace Strayacoin_Miner_v0._06a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the AsciiTableDrawer
            AsciiTableDrawer atd = new AsciiTableDrawer(ConsoleColor.DarkGray,ConsoleColor.Cyan,140,4,"Left");
            // Initialize the FileBrowser
            FileBrowser fb = new FileBrowser(atd);
            // Initialize the StrayacoinConfig
            MinerSettings ms = new MinerSettings();
            // Initialize the OutputManager
            OutputManager om = new OutputManager(3000);
            // Initialize the sm_lib
            sm_lib sml = new sm_lib(ms.CliExecutable);
            // Initialize the ohm_lib
            ohm_lib hardwareMonitor = new ohm_lib();
            // Set the console window size
            Console.SetWindowSize(140, 34);

            InputManager im = new InputManager();
            string userInput = "Escape";
            string keyPressed;
            while ((keyPressed = im.ListenForKeyPress()) != userInput)
            {
                    
                if(keyPressed == "Left")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(keyPressed);
                }
            }
            Console.ReadLine();


            UI_Renderer.Installation.Initialize(atd, fb);
            UI_Renderer.InitMessages.Init_SplashScreen();
            UI_Renderer.Installation.Installation_Startup();
            Console.ReadLine();

            // Initialize the UI Renderer
            UI_Renderer.InitMessages.Initialize(atd, fb);

            // Program Starts Here
            //UI_Renderer.InitMessages.Init_WelcomeMessage();
            // first thing we need to do is check if the miner is setup, we need to get that information from the MinerSettings.json file.
            bool result_JsonCheck = ms.CheckJson();
            if (result_JsonCheck == true)
            {   
                
            }
            Console.ReadLine();

        }

        private static bool MinerInit(MinerSettings ms)
        {
            // Check if the setup is completed
            
            // if the SetupCompleted property is false, we should check that the user has not manually setup the miner
            if (ms.SetupCompleted == false)
            {
                // Display the max cores available message
                UI_Renderer.InitMessages.Init_MaxCoresAvailable();
                
                // Display the mining cores allowed message
                UI_Renderer.InitMessages.Init_MiningCoresAllowed();
                
                // Display the wallet executable message
                UI_Renderer.InitMessages.Init_WalletExecutable();
                
                // Display the CLI executable message
                UI_Renderer.InitMessages.Init_CliExecutable();
                
                // Display the config file wallet message
                UI_Renderer.InitMessages.Init_ConfigFile_Wallet();
                
                // Display the config file user message
                UI_Renderer.InitMessages.Init_ConfigFile_User();
                
            }
            
            return ms.SetupCompleted;
        }
    }
}
