using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    class InputManager
    {
        private readonly UI_Renderer uir;

        public InputManager(UI_Renderer UIR)
        {
            uir = UIR;
        }
        // Method to read input from the console
        public string ReadInput()
        {
            Console.Write("Enter input: ");
            return Console.ReadLine();
        }

        // Method to validate the input
        public bool ValidateInput(string input)
        {
            // Basic validation: check if input is not empty
            return !string.IsNullOrEmpty(input);
        }

        // Method to parse the input
        public int ParseInput(string input)
        {
            // Try to parse the input to an integer
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Input is not a valid integer.");
            }
        }

        // Method to continuously listen for input
        public void ListenForInput()
        {
            while (true)
            {
                string input = ReadInput();

                if (ValidateInput(input))
                {
                    try
                    {
                        int parsedInput = ParseInput(input);
                        Console.WriteLine($"Parsed input: {parsedInput}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                // Exit condition (e.g., user types "exit")
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        // Method to listen for specific key presses
        public string ListenForKeyPress()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    return "Right";
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    return "Left";
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    return "Up";
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    return "Down";
                }
                else if (keyInfo.Key == ConsoleKey.Home)
                {
                    return "Home";
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    return "Backspace";
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return "Enter";
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "Escape";
                }
                else
                {
                    return keyInfo.KeyChar.ToString();
                }
            }
        }
    }
}
