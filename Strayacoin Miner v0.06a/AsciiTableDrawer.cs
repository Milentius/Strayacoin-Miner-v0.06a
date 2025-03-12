using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ascii_Table_Drawer
{
    public class AsciiTableDrawer
    {
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public int TableWidth { get; set; }
        public int Padding { get; set; }
        public string TextAlignment { get; set; }


        public AsciiTableDrawer(ConsoleColor borderColor = ConsoleColor.DarkGray, ConsoleColor textColor = ConsoleColor.Cyan, int width = 80, int padding = 4,string textAlignment = "Left")
        {
            BorderColor = borderColor;
            TextColor = textColor;
            TableWidth = width;
            Padding = padding;
            TextAlignment = textAlignment;
        }

        private void WriteInColor(string text, ConsoleColor color,bool newLine)
        {
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(text);

            }
            else
            {
                Console.Write(text);

            }

            Console.ResetColor();
        }

        public void DrawRow(string text, bool newLine = true)
        {
            if (TextAlignment == "left" || TextAlignment == "Left" || TextAlignment == "l" || TextAlignment == "L")
            {
                DrawRow_Left(text, newLine);
            }
            if (TextAlignment == "center" || TextAlignment == "Center" || TextAlignment == "c" || TextAlignment == "C")
            {
                DrawRow_Centered(text, newLine);
            }
            if (TextAlignment == "right" || TextAlignment == "Right" || TextAlignment == "r" || TextAlignment == "R")
            {
                DrawRow_Right(text, newLine);
            }
        }

        public void DrawTopBorder(bool newLine)
        {
            WriteInColor('█' + new string('▀', TableWidth - 2) + '█', BorderColor, newLine);
        }

        public void DrawBottomBorder(bool newLine)
        {
            WriteInColor('█' + new string('▄', TableWidth - 2) + '█', BorderColor, newLine);
        }

        // draw a row with a text string and borders
        public void DrawRow_Left(string text, bool newLine)
        {
            text = text.PadRight(TableWidth - 4 - Padding * 2);

            // Draw left border in border color
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");

            // Draw text in text color
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding) + text + new string(' ', Padding));

            // Draw right border in border color and move to next line
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine(" █");
                
            }
            else
            {
                Console.Write(" █");
            }
            Console.ResetColor();
        }

        public void DrawRow_Right(string text,bool newLine)
        {
            // Calculate the right padding needed to right-align the text
            int textLength = text.Length;
            int totalTextSpace = TableWidth - 4 - Padding * 2; // Total space available for text
            int rightPadding = totalTextSpace - textLength; // Padding needed to push text to the right

            // Ensure rightPadding is not negative
            rightPadding = Math.Max(0, rightPadding);

            // Draw left border in border color
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");

            // Draw left padding, then text, in text color
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding + rightPadding) + text);

            // Draw right border in border color and move to next line
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine(" █");

            }
            else
            {
                Console.Write(" █");

            }
            Console.ResetColor();
        }


        public void DrawRow_Centered(string text,bool newLine)
        {
            // Calculate the space needed to center the text within the table width
            int totalPadding = TableWidth - 2 - text.Length; // 2 accounts for the left and right border characters
            int leftPadding = totalPadding / 2;
            int rightPadding = totalPadding - leftPadding;

            // Ensure that the combined length of text and padding fits exactly within the table width
            if ((text.Length + leftPadding + rightPadding + 2) < TableWidth)
            {
                rightPadding += TableWidth - (text.Length + leftPadding + rightPadding + 2);
            }

            // Draw left border in border color
            Console.ForegroundColor = BorderColor;
            Console.Write("█");

            // Draw left padding and text in text color
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', leftPadding) + text);

            // Draw right padding in text color (to ensure consistent background color)
            Console.Write(new string(' ', rightPadding));

            // Draw right border in border color and move to next line
            Console.ForegroundColor = BorderColor;
            if(newLine)
            {
                Console.WriteLine("█");

            }
            else
            {
                Console.Write("█");
            }
            Console.ResetColor();
        }

        public void DrawEmptyRow(bool newLine)
        {
            WriteInColor('█' + new string(' ', TableWidth - 2) + '█', BorderColor,newLine);
        }

        public void DrawSeparator(bool newLine)
        {
            WriteInColor('█' + new string('█', TableWidth - 2) + '█', BorderColor, newLine);
        }

        
        public void DrawUpperSeparator(bool newLine)
        {
            WriteInColor('█' + new string('▀', TableWidth - 2) + '█', BorderColor, newLine);
        }

        public void DrawLowerSeparator(bool newLine)
        {
            WriteInColor('█' + new string('▄', TableWidth - 2) + '█', BorderColor, newLine);
        }

        public string GetUserInput(string prompt,bool newLine)
        {
            //DrawTopBorder();

            // Draw left border and prompt
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding) + prompt);
            Console.ResetColor();

            // Set the cursor position to start of user input area
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            // Read user input on the same line as the prompt
            string userInput = Console.ReadLine();

            // Calculate the remaining space and fill it with spaces
            int usedSpace = cursorLeft + userInput.Length - 2; // 2 for left border and space
            int remainingSpace = TableWidth - usedSpace - 3; // 3 for right border and space
            string filler = new string(' ', remainingSpace);

            // Move the cursor back to the end of user input and draw the filler and right border
            Console.SetCursorPosition(cursorLeft + userInput.Length, cursorTop);
            Console.Write(filler);
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine("█");

            }
            else
            {
                Console.Write("█");
            }
            Console.ResetColor();

            //DrawBottomHalfOfBox();
            return userInput;
        }

        public void DrawHeading(string optionText,bool newLine)
        {
            DrawEmptyRow(newLine); // Draws an empty row above the option text
            DrawRow_Centered(optionText, newLine); // Draws the row with the option text
            DrawEmptyRow(newLine); // Draws an empty row below the option text
        }

        public string GetUserInputWithBar(string leftContent, string prompt, bool newLine = true, int barIndex = 4)
        {
            // Calculate space for left content and vertical bar
            int leftSpace = barIndex - 1;

            // Draw left border and left content
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");
            Console.ForegroundColor = TextColor;
            Console.Write(leftContent.PadRight(leftSpace - 2));

            // Draw vertical bar
            Console.ForegroundColor = BorderColor;
            Console.Write(" █ ");

            // Write prompt and set cursor position for user input
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding) + prompt);
            Console.ResetColor();

            int startInputCursorLeft = Console.CursorLeft;

            // Read user input
            string userInput = Console.ReadLine();

            // Calculate remaining space and draw filler and right border
            int usedSpace = startInputCursorLeft + userInput.Length - leftSpace - 3; // Adjust for left content and borders
            int remainingSpace = TableWidth - usedSpace - 7; // 3 for right border and space
            string filler = new string(' ', Math.Max(0, remainingSpace));

            Console.SetCursorPosition(startInputCursorLeft + userInput.Length, Console.CursorTop - 1);
            Console.Write(filler);
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine("█");

            }
            else
            {
                Console.Write("█");

            }
            Console.ResetColor();

            return userInput;
        }

        public void DrawUpperSeparatorWithBar(int barPosition = 4,bool newLine = true)
        {
            DrawSeparatorWithBar('▀',barPosition,newLine);
        }

        public void DrawLowerSeparatorWithBar(int barPosition = 4)
        {
            DrawSeparatorWithBar('▄', barPosition);
        }

        public void DrawRowWithBar(string leftContent, ConsoleColor leftContentColor, string text, int barIndex = 4,bool newLine = true)
        {
            // Adjust barIndex to zero-based index
            int zeroBasedBarIndex = barIndex - 1;

            // Prepare the text with padding
            int mainTextLength = TableWidth - zeroBasedBarIndex - 4 - Padding * 2;
            text = text.PadRight(mainTextLength);

            // Draw left border in border color
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");

            // Draw left content in leftContentColor, right-aligned within its space
            Console.ForegroundColor = leftContentColor;
            Console.Write(leftContent.PadLeft(zeroBasedBarIndex - 2));

            // Draw vertical bar in border color
            Console.ForegroundColor = BorderColor;
            Console.Write(" █ ");

            // Draw main text in text color
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding) + text);

            // Draw right border in border color and move to next line
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine(new string(' ', Padding) + "█");

            }
            else
            {
                Console.Write(new string(' ', Padding) + "█");

            }
            Console.ResetColor();
        }

        public void DrawSeparatorWithBar(char separatorChar, int barPosition = 4 , bool newLine = true)
        {
            string separator = $"█{new string(separatorChar, barPosition - 1)}█{new string(separatorChar, TableWidth - barPosition - 2)}█";
            WriteInColor(separator, BorderColor,newLine);
        }

        // displays a progress bar
        public void DisplayProgressBar(int progress, int total, bool newLine)
        {
            // Validate inputs
            if (total <= 0)
            {
                throw new ArgumentException("Total must be greater than 0.", nameof(total));
            }

            if (progress < 0 || progress > total)
            {
                throw new ArgumentException("Progress must be between 0 and total.", nameof(progress));
            }

            // Calculate the width of the progress bar
            int totalBlocks = Math.Max(0, TableWidth - 4);  // Subtract 4 in advance to align, ensuring it's not negative

            double fractionDone = (double)progress / total;
            int shadedBlocks = (int)(fractionDone * totalBlocks);

            // Ensure shadedBlocks is not more than totalBlocks
            shadedBlocks = Math.Min(shadedBlocks, totalBlocks);

            // Ensure the number of '-' characters is not negative
            int unshadedBlocks = Math.Max(0, totalBlocks - shadedBlocks);

            // Build the progress bar string
            string progressBar = new string('█', shadedBlocks) + new string('-', unshadedBlocks);

            // Construct the progress bar text
            string progressBarText = $"{progressBar}";

            // Draw the progress bar using the table drawer methods
            DrawProgressWithColor(progressBarText, TextColor, newLine);  // This is a method to draw rows with specific colors
        }

        private void DrawProgressWithColor(string text, ConsoleColor barColor,bool newLine)
        {
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");
            Console.ForegroundColor = barColor;
            Console.Write(text.PadRight(TableWidth - 4)); // Padding for borders
            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine(" █");

            }
            else
            {
                Console.Write(" █");

            }
            Console.ResetColor();
        }

        public string GetMaskedUserInput(string leftContent, string prompt, string MaskCharacter = "*",bool newLine = true, int barIndex = 4)
        {
            //DrawTopBorder();

            // Calculate space for left content and vertical bar
            int leftSpace = barIndex - 1;

            // Draw left border and left content
            Console.ForegroundColor = BorderColor;
            Console.Write("█ ");
            Console.ForegroundColor = TextColor;
            Console.Write(leftContent.PadRight(leftSpace - 2));

            // Draw vertical bar
            Console.ForegroundColor = BorderColor;
            Console.Write(" █ ");

            // Write prompt
            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', Padding) + prompt);
            Console.ResetColor();

            // Start reading the password
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Add character to password or handle backspace
                if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                {
                    password += key.KeyChar;
                    //Console.Write("*");
                    Console.Write(MaskCharacter);
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b"); // Erase the last asterisk from the console
                }
            } while (key.Key != ConsoleKey.Enter);

            // End the row and draw bottom border
            int remainingSpace = TableWidth - Console.CursorLeft - 1;
            Console.Write(new string(' ', remainingSpace) + "█");
            if (newLine)
            {
                Console.WriteLine();

            }
            
            //DrawBottomBorder();

            return password;
        }

        // draw a list of options to display to the user
        public void DrawOptionsList(string leftText, string rightText,bool newLine)
        {
            int middlePoint = TableWidth / 2; // Middle of the table

            // Calculate available space for text on each side of the vertical bar
            int availableLeftSpace = middlePoint - 2; // 1 space for left border, 1 for vertical bar
            int availableRightSpace = TableWidth - middlePoint - 3; // 1 for vertical bar, 2 for right border

            // Center the text within the available space on each side
            int leftPadding = (availableLeftSpace - leftText.Length) / 2;
            int rightPadding = (availableRightSpace - rightText.Length) / 2;

            // Ensure padding is not negative
            leftPadding = Math.Max(0, leftPadding);
            rightPadding = Math.Max(0, rightPadding);

            // Construct the row
            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Left border

            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', leftPadding) + leftText);
            Console.Write(new string(' ', availableLeftSpace - leftText.Length - leftPadding));

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Vertical bar

            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', rightPadding + 1) + rightText);
            Console.Write(new string(' ', availableRightSpace - rightText.Length - rightPadding + 1));

            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine("█"); // Right border

            }
            else
            {
                Console.Write("█"); // Right border

            }
            Console.ResetColor();
        }

       

        // draw and upper seperator for the options list
        public void DrawUpperOptionListSeparator(bool newLine = true)
        {
            int middlePoint = TableWidth / 2; // Calculate the middle of the table

            // Adjust for the removed spaces, similar to DrawOptionsList
            int extraSpaces = 1; // Total spaces removed
            int leftHalf = middlePoint - 2 + extraSpaces / 2; // Distribute half to the left side
            int rightHalf = TableWidth - middlePoint - 2 + extraSpaces - extraSpaces / 2; // Distribute the remainder to the right side

            // Draw the upper separator with a vertical bar in the middle
            Console.ForegroundColor = BorderColor;
            Console.Write("█" + new string('▀', leftHalf) + "█" + new string('▀', rightHalf) + "█");
            if (newLine)
            {
                Console.WriteLine();

            }
            Console.ResetColor();
        }

        // draw and lower seperator for the options list
        public void DrawLowerOptionListSeparator(bool newLine = true)
        {
            int middlePoint = TableWidth / 2; // Calculate the middle of the table

            // Adjust for the removed spaces, similar to DrawOptionsList
            int extraSpaces = 1; // Total spaces removed
            int leftHalf = middlePoint - 2 + extraSpaces / 2; // Distribute half to the left side
            int rightHalf = TableWidth - middlePoint - 2 + extraSpaces - extraSpaces / 2; // Distribute the remainder to the right side

            // Draw the lower separator with a vertical bar in the middle
            Console.ForegroundColor = BorderColor;
            Console.Write("█" + new string('▄', leftHalf) + "█" + new string('▄', rightHalf) + "█");
            if (newLine)
            {
                Console.WriteLine();

            }
            
            Console.ResetColor();
        }

        


        // draw an options list with a bar on the left of each option
        public void DrawOptionsListWithBar(string leftNumber, string leftOption, string rightNumber, string rightOption,bool newLine = true)
        {
            int halfWidth = TableWidth / 2; // Half of the table width to accommodate two sections

            // Left section
            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Left border

            Console.ForegroundColor = TextColor;
            Console.Write($" {leftNumber} "); // Left number with padding

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Vertical bar after the left number

            Console.ForegroundColor = TextColor;
            // Adjust leftOptionPadding by reducing 3 spaces
            int leftOptionPadding = halfWidth - leftNumber.Length - 4 - leftOption.Length - 3; // Calculate padding for left option
            Console.Write($" {leftOption}{new string(' ', leftOptionPadding)}"); // Left option with padding

            // Right section
            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Middle vertical bar

            Console.ForegroundColor = TextColor;
            Console.Write($" {rightNumber} "); // Right number with padding

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Vertical bar after the right number

            Console.ForegroundColor = TextColor;
            int rightOptionPadding = halfWidth - rightNumber.Length - 4 - rightOption.Length; // Calculate padding for right option
            Console.Write($" {rightOption}{new string(' ', rightOptionPadding)}"); // Right option with padding

            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine("█"); // Right border

            }
            else
            {

                Console.Write("█"); // Right border
            }
            Console.ResetColor();
        }

        public void DrawUpperOptionsListSeparatorWithBar(bool newLine = true)
        {
            // Define the width of the number slots, assuming a fixed width for simplicity
            int numberSlotWidth = 3; // Includes the space for the number and padding around it

            // Calculate the remaining width for the option slots after accounting for number slots and vertical bars
            int optionSlotWidth = (TableWidth / 2) - numberSlotWidth - 1; // -1 for the vertical bar after the number slot

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Start with the left border

            // Left number slot
            Console.Write(new string('▀', numberSlotWidth) + "█");

            // Left option slot
            Console.Write(new string('▀', optionSlotWidth - 3)); //** the "-3" here is because of the left border and the left vertical bar after the number slot, then we anticipate that there is 1 more bar to come, the middle bar

            // Middle vertical bar, marking the end of the left section and the start of the right section
            Console.Write("█");

            // Right number slot
            Console.Write(new string('▀', numberSlotWidth) + "█");

            // Right option slot
            Console.Write(new string('▀', optionSlotWidth));

            // Complete the line with the right border
            if (newLine)
            {
                Console.WriteLine("█");

            }
            else
            {
                Console.Write("█");

            }
            Console.ResetColor();
        }

        public void DrawLowerOptionsListSeparatorWithBar(bool newLine = true)
        {
            // Define the width of the number slots, assuming a fixed width for simplicity
            int numberSlotWidth = 3; // Includes the space for the number and padding around it

            // Calculate the remaining width for the option slots after accounting for number slots and vertical bars
            int optionSlotWidth = (TableWidth / 2) - numberSlotWidth - 1; // -1 for the vertical bar after the number slot

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Start with the left border

            // Left number slot
            Console.Write(new string('▄', numberSlotWidth) + "█");

            // Left option slot, with adjustment for the anticipated middle vertical bar
            Console.Write(new string('▄', optionSlotWidth - 3)); // the "-3" adjustment accounts for the left border, the left vertical bar, and the anticipated middle bar

            // Middle vertical bar, marking the end of the left section and the start of the right section
            Console.Write("█");

            // Right number slot
            Console.Write(new string('▄', numberSlotWidth) + "█");

            // Right option slot, without the need for the "-3" adjustment as there's no anticipated bar on the right
            Console.Write(new string('▄', optionSlotWidth));

            // Complete the line with the right border
            if (newLine)
            {
                Console.WriteLine("█");

            }
            else
            {
                Console.Write("█");

            }
            Console.ResetColor();
        }

        // draws a centered options list with a left section, uses the same separators a the normal "WithBar" borders
        public void DrawCenteredOptionsListWithBar(string leftNumber, string leftText, string rightNumber, string rightText,bool newLine = true)
        {
            int leftNumberWidth = leftNumber.Length + 4; // Assuming 2 spaces padding + 2 for the bars around the number
            int rightNumberWidth = rightNumber.Length + 4; // Same as above

            int middlePoint = TableWidth / 2; // Middle of the table

            // Calculate the available space for text on each side, excluding the space for the number and vertical bars
            int availableLeftSpace = middlePoint - leftNumberWidth - 1; // -1 for the vertical bar after the left number
            int availableRightSpace = middlePoint - rightNumberWidth - 1; // -1 for the vertical bar after the right number

            // Calculate padding for center alignment
            int leftPadding = (availableLeftSpace - leftText.Length) / 2;
            int rightPadding = (availableRightSpace - rightText.Length) / 2;

            // Ensure padding is not negative
            leftPadding = Math.Max(0, leftPadding);
            rightPadding = Math.Max(0, rightPadding);

            // Construct the centered row
            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Left border

            Console.ForegroundColor = TextColor;
            Console.Write($" {leftNumber} "); // Left number with padding

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Vertical bar after the left number

            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', leftPadding - 1) + leftText);
            Console.Write(new string(' ', availableLeftSpace - leftText.Length - leftPadding));

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Middle vertical bar

            Console.ForegroundColor = TextColor;
            Console.Write($" {rightNumber} "); // Right number with padding

            Console.ForegroundColor = BorderColor;
            Console.Write("█"); // Vertical bar after the right number

            Console.ForegroundColor = TextColor;
            Console.Write(new string(' ', rightPadding + 2) + rightText);
            Console.Write(new string(' ', availableRightSpace - rightText.Length - rightPadding));

            Console.ForegroundColor = BorderColor;
            if (newLine)
            {
                Console.WriteLine("█"); // Right border

            }
            else
            {
                Console.Write("█"); // Right border

            }
            Console.ResetColor();
        }

    }
}
