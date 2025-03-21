﻿using Ascii_Table_Drawer;
using File_Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    public class UI_Renderer
    {
        private readonly AsciiTableDrawer atd;
        static Random randy = new Random();

        public UI_Renderer(AsciiTableDrawer ATD)
        {
            atd = ATD;
        }

        public static class InitMessages
        {
            private static AsciiTableDrawer atd;
            private static FileBrowser fb;

            public static void Initialize(AsciiTableDrawer ATD, FileBrowser FB)
            {
                atd = ATD;
                fb = FB;
            }

            public static void Init_SplashScreen()
            {
                Console.SetWindowSize(150, 45);
                Console.WriteLine(@"                                                                                                                                          ");
                Console.WriteLine(@"                                                                                                                                          ");
                Console.WriteLine(@"                                 ███████ ████████ ██████   █████  ██    ██  █████   ██████  ██████  ██ ███    ██                          ");
                Console.WriteLine(@"                                 ██         ██    ██   ██ ██   ██  ██  ██  ██   ██ ██      ██    ██ ██ ████   ██                          ");
                Console.WriteLine(@"                                 ███████    ██    ██████  ███████   ████   ███████ ██      ██    ██ ██ ██ ██  ██                          ");
                Console.WriteLine(@"                                      ██    ██    ██   ██ ██   ██    ██    ██   ██ ██      ██    ██ ██ ██  ██ ██                          ");
                Console.WriteLine(@"                                 ███████    ██    ██   ██ ██   ██    ██    ██   ██  ██████  ██████  ██ ██   ████                          ");
                Console.WriteLine(@"                                                                                                                                          ");
                Console.WriteLine(@"                                                                                      ██████                                              ");
                Console.WriteLine(@"                                                                                      ██░░░░██                                            ");
                Console.WriteLine(@"                                                                                      ██░░░░░░██████                                      ");
                Console.WriteLine(@"                                                                                      ██░░░░░░░░░░░░████                                  ");
                Console.WriteLine(@"                                                                                        ██░░░░░░░░██░░░░██                                ");
                Console.WriteLine(@"                                                                                        ██░░░░░░░░░░░░░░░░████                            ");
                Console.WriteLine(@"                                                                                        ██▒▒░░░░░░░░░░░░░░▒▒▒▒██                          ");
                Console.WriteLine(@"                                                                                      ██░░░░▒▒▒▒░░░░░░░░▒▒▒▒▒▒██                          ");
                Console.WriteLine(@"                                                                                    ██░░░░░░░░▒▒▒▒▒▒██████████                            ");
                Console.WriteLine(@"                                                                    ████████████████░░░░░░░░░░▒▒▒▒██                                      ");
                Console.WriteLine(@"                                                            ████████░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒██                                        ");
                Console.WriteLine(@"                                                          ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒██                                        ");
                Console.WriteLine(@"                                                        ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒██                                          ");
                Console.WriteLine(@"                                                      ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒██                                            ");
                Console.WriteLine(@"                                                    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                                          ");
                Console.WriteLine(@"                                                    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                                          ");
                Console.WriteLine(@"                                                  ██░░░░██░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░██                                          ");
                Console.WriteLine(@"                                                  ██░░██░░░░░░░░░░░░░░████░░░░▒▒▒▒▒▒▒▒▒▒██░░░░████                                        ");
                Console.WriteLine(@"                                                  ██░░██░░░░░░░░░░░░░░░░██░░▒▒▒▒▒▒▒▒▒▒████▒▒░░░░██                                        ");
                Console.WriteLine(@"                                                ██░░░░██▒▒░░░░░░░░░░░░░░██▒▒▒▒▒▒██████  ██▒▒▒▒░░██                                        ");
                Console.WriteLine(@"                                                ██░░░░██▒▒▒▒░░░░░░░░░░░░░░██▒▒▒▒██        ██▒▒░░██                                        ");
                Console.WriteLine(@"                                                ██░░░░▒▒██▒▒▒▒░░░░░░░░░░░░██████          ██▒▒▒▒██                                        ");
                Console.WriteLine(@"                                              ██░░░░░░▒▒██▒▒▒▒▒▒░░░░░░░░░░██              ██▒▒██                                          ");
                Console.WriteLine(@"                                              ██░░░░▒▒▒▒██▒▒▒▒▒▒░░░░░░░░██                  ██                                            ");
                Console.WriteLine(@"                                            ██░░░░▒▒▒▒▒▒████▒▒▒▒▒▒░░░░░░██                                                                ");
                Console.WriteLine(@"                                          ██░░░░▒▒▒▒▒▒████████▒▒▒▒░░░░██                                                                  ");
                Console.WriteLine(@"                                      ████░░░░▒▒▒▒▒▒██  ██████▒▒▒▒▒▒████              Visit The Strayacoin                                ");
                Console.WriteLine(@"                              ████████░░░░░░▒▒▒▒▒▒██      ████▒▒▒▒▒▒██                Discord For Help!                                   ");
                Console.WriteLine(@"                        ██████░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒██        ██████▒▒▒▒██                                                                    ");
                Console.WriteLine(@"                      ██░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒████          ██████▒▒▒▒░░██████████                                                          ");
                Console.WriteLine(@"                      ██████████████████████              ██████████▒▒▒▒▒▒░░░░░░██                                                        ");
                Console.WriteLine(@"                                                            ██████████████████████                                                        ");
                Console.WriteLine(@"                                                                                                                                          ");
                Console.WriteLine(@"                                                                                                                                          ");
                Thread.Sleep(4000);
                Console.SetWindowSize(150, 34);
                // Implementation of InitMessage1
                //Console.Clear();
                //atd.DrawTopBorder(true);
                //atd.DrawHeading("Strayacoin Miner v0.06a", true);
                //atd.DrawHeading("Welcome to Strayacoin Miner", true);
                //atd.DrawHeading("Starting Up: Checking Config", true);
                //atd.DrawBottomBorder(true);
                //atd.DrawTopBorder(true);
                //atd.DisplayProgressBar(1,20,true);
                //atd.DrawTopBorder(true);
                //Thread.Sleep(300);
            }

            public static void Init_HomePage()
            {



                // this shows if the setup is complete and we do not have to check anything else.
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: Setup Complete, Starting Miner...", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(2, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(200);
            }

            public static void Init_MaxCoresAvailable()
            {
                // Implementation of InitMessage1
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Checking Setting: Max Cores Available", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(3, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(600);
            }

            public static void Init_MiningCoresAllowed()
            {
                // Implementation of InitMessage1
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: Max Cores Allowed", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(4, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(1000);
            }

            public static void Init_WalletExecutable()
            {
                // Implementation of InitMessage2
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: Wallet Executable", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(5, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(300);
            }

            public static void Init_CliExecutable()
            {
                // Implementation of InitMessage3
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: CLI Executable", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(6, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(300);
            }

            public static void Init_ConfigFile_Wallet()
            {
                // Implementation of InitMessage4
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: Checking Wallet Config", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(7, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(300);
            }

            public static void Init_ConfigFile_User()
            {
                // Implementation of InitMessage5
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawHeading("Welcome to Strayacoin Miner", true);
                atd.DrawHeading("Starting Up: Checking User Config", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(8, 20, true);
                atd.DrawTopBorder(true);
                Thread.Sleep(300);
            }
            // Add more methods as needed
        }

        public static class Mining
        {
            private static AsciiTableDrawer atd;

            public static void Initialize(AsciiTableDrawer ATD)
            {
                atd = ATD;
            }

            public static void MiningMessage1()
            {
                // Implementation of MiningMessage1
                Console.WriteLine("MiningMessage1 called");
            }

            public static void VisualBlockIndicator(int blocksMined, int blocksImmature)
            {
                ConsoleColor baseColor = atd.BorderColor;
                ConsoleColor textColor = atd.TextColor;
                // Implementation of MiningMessage1
                Console.WriteLine("MiningMessage1 called");
            }

            // Add more methods as needed
        }

        public static class Configuration
        {
            private static AsciiTableDrawer atd;

            public static void Initialize(AsciiTableDrawer ATD)
            {
                atd = ATD;
            }

            public static void UpdateMiningCores(int CurrentSetting,int NewSetting)
            {
                // we will have a way to retrive the current setting from the MinerSettings file and a way to update the MinerSettings file
                
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DrawRow_Centered($"Allowed Cores updated from {CurrentSetting} to {NewSetting}", true);
                atd.DrawRow_Centered("This will come into effect on the next block", true);
                atd.DrawBottomBorder(true);
            }



            // Add more methods as needed
        }

        public static class Installation
        {
            private static AsciiTableDrawer atd;
            private static FileBrowser fb;

            public static void Initialize(AsciiTableDrawer ATD, FileBrowser FB)
            {
                atd = ATD;
                fb = FB;
            }

            public static void InstallationMessage1()
            {
                // Implementation of InstallationMessage1
                Console.WriteLine("InstallationMessage1 called");
            }


            public static string Installation_Startup()
            {
                // we will have a way to retrive the current setting from the MinerSettings file and a way to update the MinerSettings file

                string[] heading = { "Strayacoin Miner v0.06a", "First Run Detected" };
                string[] infoSecion = { "Before the miner can continue, it needs to be setup.", "This will be a one time Setup but it can be run", "at any time with launch paramters.", " Check the Readme for more information" };
                string[] menuItems = { "Automatic Setup", "Manual Setup" , "I dont understand, i need more information", "Quit" };
                string[] returnValues = { "Auto", "Manual", "More", "Quit"};

                string output = fb.ShowMenu(heading, infoSecion, menuItems, returnValues);
                if (output == "More")
                {
                    // we will have a way to retrive the current setting from the MinerSettings file and a way to update the MinerSettings file
                    
                    string[] headingMore = { "Strayacoin Miner v0.06a", "First Run Detected" };
                    string[] infoSecionMore = { 
                        "Manual Setup: this allows you to setup the miner by selecting or entering each setting manually.", 
                        "This gives you more freedom to use the miner how you want but takes more time to setup", 
                        "", 
                        "Automatic Setup: This will first scan your PC hardware, then setup the miner for your hardware as best it can.",
                        "You will have a chance to review the settings before they are saved and applied",
                        "",
                        "In both cases you can change the settings later with commands.", 
                        "",
                        "No personal data is collected by the miner and there is no call home or update features for security reasons.",
                        "The miner collects only the CPU Core Count, CPU Thread Count, CPU Max Temp(TJ Max), CPU Speed." 
                    };

                    string[] menuItemsMore = { "Automatic Setup", "Manually Setup", "Quit"};
                    string[] returnValuesMore = { "Auto", "Manual", "quit"};
                    
                    string outputMore = fb.ShowMenu(headingMore, infoSecionMore, menuItemsMore, returnValuesMore);
                    return outputMore;
                }
                return output;
            }

            public static void AutomaticInstall()
            {
                Console.Clear();
                atd.DrawTopBorder(true);
                atd.DrawHeading("Strayacoin Miner v0.06a", true);
                atd.DrawRow_Centered("Automatic Installation", true);
                atd.DrawBottomBorder(true);
                atd.DrawTopBorder(true);
                atd.DisplayProgressBar(0,100, true);
                atd.DrawRow_Centered("", true);
                atd.DrawRow_Centered("", true);
                atd.DrawBottomBorder(true);
            }
            // Add more methods as needed
        }
    }
}
