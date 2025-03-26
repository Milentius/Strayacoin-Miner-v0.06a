﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Strayacoin_Miner_v0._06a
{
    public class FileBrowser
    {
        public static AsciiTableDrawer atd;

        public int FileBrowserWidth { get; set; }
        public int FileBrowserHeight { get; set; }

        public FileBrowser(AsciiTableDrawer asciiTableDrawer)
        {
            atd = asciiTableDrawer;
        }

        public string ShowMenuWithScrollingAndBar(string[] headings, string[] infoSection, string[] menuItems, string[] returnValues)
        {
            int selectedItemIndex = 0;
            int visibleItemsCount = 10;
            int topItemIndex = 0;

            ConsoleKey key;
            do
            {
                Console.Clear();
                DrawHeadings(headings);
                int bottomItemIndex = Math.Min(topItemIndex + visibleItemsCount - 2, menuItems.Length + 1);
                double scrollbarPosition = (double)topItemIndex / (menuItems.Length - (visibleItemsCount - 1));
                int scrollbarIndicatorPosition = (int)(scrollbarPosition * (visibleItemsCount - 3));

                DrawTopScrollIndicator(topItemIndex, menuItems.Length, visibleItemsCount);
                DrawMenuItems(menuItems, selectedItemIndex, topItemIndex, visibleItemsCount, scrollbarIndicatorPosition);
                DrawBottomScrollIndicator(bottomItemIndex, menuItems.Length);

                key = Console.ReadKey(true).Key;
                UpdateSelectedItemIndex(ref selectedItemIndex, ref topItemIndex, key, menuItems.Length, visibleItemsCount);
            } while (key != ConsoleKey.Enter);

            return returnValues[selectedItemIndex];
        }

        private void DrawHeadings(string[] headings)
        {
            atd.StandardDrawer.DrawTopBorder(true);
            foreach (var heading in headings)
            {
                atd.StandardDrawer.DrawEmptyRow(true);
                atd.StandardDrawer.DrawRow(heading, true);
                atd.StandardDrawer.DrawEmptyRow(true);
            }
            atd.StandardDrawer.DrawBottomBorder(true);
        }

        private void DrawTopScrollIndicator(int topItemIndex, int menuItemsLength, int visibleItemsCount)
        {
            atd.StandardDrawer.DrawTopBorder(true);
            int potentialTopIndexAtBottom = menuItemsLength - (visibleItemsCount - 1);
            int effectiveTopIndex = Math.Min(topItemIndex, potentialTopIndexAtBottom);
            int topMoreItems = effectiveTopIndex;
            atd.StandardDrawer.DrawRow(topItemIndex > 0 ? $"↑   +{topMoreItems} more items" : "- ", true);
            atd.StandardDrawer.DrawBottomBorder(true);
        }

        private void DrawMenuItems(string[] menuItems, int selectedItemIndex, int topItemIndex, int visibleItemsCount, int scrollbarIndicatorPosition)
        {
            atd.StandardDrawer.DrawTopBorder(true);
            for (int i = 0; i < visibleItemsCount - 2; i++)
            {
                int itemIndex = topItemIndex + i;
                if (itemIndex < menuItems.Length)
                {
                    string scrollbarIndicator = i == scrollbarIndicatorPosition ? "█" : " ";
                    if (itemIndex == selectedItemIndex)
                    {
                        atd.TextColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        atd.StandardDrawer.DrawRow($"{scrollbarIndicator} > {menuItems[itemIndex]}", true);
                        Console.BackgroundColor = ConsoleColor.Black;
                        atd.TextColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        atd.StandardDrawer.DrawRow($"{scrollbarIndicator}   {menuItems[itemIndex]}", true);
                    }
                }
            }
            atd.StandardDrawer.DrawBottomBorder(true);
        }

        private void DrawBottomScrollIndicator(int bottomItemIndex, int menuItemsLength)
        {
            atd.StandardDrawer.DrawTopBorder(true);
            int bottomMoreItems = menuItemsLength - (bottomItemIndex + 1);
            atd.StandardDrawer.DrawRow((bottomItemIndex + 1 < menuItemsLength) ? $"↓   +{bottomMoreItems} more items" : "- ", true);
            atd.StandardDrawer.DrawBottomBorder(true);
        }

        private void UpdateSelectedItemIndex(ref int selectedItemIndex, ref int topItemIndex, ConsoleKey key, int menuItemsLength, int visibleItemsCount)
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (selectedItemIndex > 0)
                {
                    selectedItemIndex--;
                    if (selectedItemIndex < topItemIndex)
                    {
                        topItemIndex = selectedItemIndex;
                    }
                    else if (selectedItemIndex < topItemIndex + (visibleItemsCount / 2))
                    {
                        topItemIndex = Math.Max(0, topItemIndex - 1);
                    }
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (selectedItemIndex < menuItemsLength - 1)
                {
                    selectedItemIndex++;
                    if (selectedItemIndex >= topItemIndex + (visibleItemsCount / 2) && selectedItemIndex < menuItemsLength - 1)
                    {
                        topItemIndex = Math.Min(menuItemsLength - (visibleItemsCount - 2), topItemIndex + 1);
                    }
                }
            }
        }

        public string ShowFileBrowser(string initialPath, string[] headings, string[] infoSections)
        {
            string currentPath = initialPath;

            while (true)
            {
                var directories = Directory.GetDirectories(currentPath).Select(Path.GetFileName).ToArray();
                var files = Directory.GetFiles(currentPath).Select(Path.GetFileName).ToArray();

                var menuItems = (currentPath != initialPath ? new[] { ".." } : new string[] { })
                                .Concat(directories.Select(d => $"[Dir] {d}"))
                                .Concat(files)
                                .ToArray();

                var returnValues = (currentPath != initialPath ? new[] { Directory.GetParent(currentPath).FullName } : new string[] { })
                                   .Concat(directories.Select(d => Path.Combine(currentPath, d)))
                                   .Concat(files.Select(f => Path.Combine(currentPath, f)))
                                   .ToArray();

                string selectedPath = ShowMenuWithScrollingAndBar(headings, infoSections, menuItems, returnValues);

                if (Directory.Exists(selectedPath))
                {
                    currentPath = selectedPath;
                }
                else if (File.Exists(selectedPath))
                {
                    return selectedPath;
                }
            }
        }


        public static string ShowMenuWithScrolling(string[] headings, string[] infoSection, string[] menuItems, string[] returnValues)
        {
            int selectedItemIndex = 0;
            int visibleItemsCount = 10;
            int topItemIndex = 0;

            ConsoleKey key;
            do
            {
                Console.Clear();
                atd.StandardDrawer.DrawTopBorder(true);
                foreach (var heading in headings)
                {
                    atd.StandardDrawer.DrawEmptyRow(true);
                    atd.StandardDrawer.DrawRow(heading, true);
                    atd.StandardDrawer.DrawEmptyRow(true);
                }
                atd.StandardDrawer.DrawBottomBorder(true);

                int bottomItemIndex = Math.Min(topItemIndex + visibleItemsCount, menuItems.Length);

                for (int i = topItemIndex; i < bottomItemIndex; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        atd.TextColor = ConsoleColor.Green;
                        atd.StandardDrawer.DrawTopBorder();
                        atd.WithBarDrawer.DrawRowWithBar($"{i + 1}->", $"{menuItems[i]}");
                        atd.StandardDrawer.DrawBottomBorder(true);
                    }
                    else
                    {
                        atd.TextColor = ConsoleColor.Red;
                        atd.StandardDrawer.DrawTopBorder();
                        atd.WithBarDrawer.DrawRowWithBar($"{i + 1}", $"{menuItems[i]}");
                        atd.StandardDrawer.DrawBottomBorder(true);
                    }
                }

                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedItemIndex = (selectedItemIndex > 0) ? selectedItemIndex - 1 : selectedItemIndex;
                    topItemIndex = (selectedItemIndex < topItemIndex) ? selectedItemIndex : topItemIndex;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedItemIndex = (selectedItemIndex < menuItems.Length - 1) ? selectedItemIndex + 1 : selectedItemIndex;
                    if (selectedItemIndex >= bottomItemIndex)
                    {
                        topItemIndex = selectedItemIndex - visibleItemsCount + 1;
                    }
                }
            } while (key != ConsoleKey.Enter);

            return returnValues[selectedItemIndex];
        }

        public string ShowMenu(string[] headings, string[] infoSection, string[] menuItems, string[] returnValues)
        {
            int selectedItemIndex = 0;

            ConsoleKey key;
            do
            {
                Console.Clear();
                atd.StandardDrawer.DrawTopBorder(true);
                foreach (var heading in headings)
                {
                    atd.StandardDrawer.DrawEmptyRow(true);
                    atd.StandardDrawer.DrawRow(heading, true);
                    atd.StandardDrawer.DrawEmptyRow(true);
                }
                atd.StandardDrawer.DrawBottomBorder();

                atd.StandardDrawer.DrawTopBorder(true);
                atd.Alignment = TextAlignment.Center;
                foreach (var info in infoSection)
                {
                    atd.StandardDrawer.DrawRow(info);
                }
                atd.StandardDrawer.DrawBottomBorder();
                atd.Alignment = TextAlignment.Left;

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        atd.TextColor = ConsoleColor.Green;
                        atd.WithBarDrawer.DrawTopBorder();
                        atd.WithBarDrawer.DrawRowWithBar($"{i + 1}->", $"{menuItems[i]}");
                        atd.StandardDrawer.DrawBottomBorder();
                    }
                    else
                    {
                        atd.TextColor = ConsoleColor.Red;
                        atd.WithBarDrawer.DrawTopBorder();
                        atd.WithBarDrawer.DrawRowWithBar($"{i + 1}", $"{menuItems[i]}");
                        atd.StandardDrawer.DrawBottomBorder();
                    }
                }
                atd.TextColor = ConsoleColor.Cyan;

                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedItemIndex = (selectedItemIndex > 0) ? selectedItemIndex - 1 : menuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length;
                }
            } while (key != ConsoleKey.Enter);

            return returnValues[selectedItemIndex];
        }

        public static string LaunchFileBrowser()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project FileBrowserProject", // Adjust the project path as needed
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd().Trim();
                }
            }
        }
    }
}



