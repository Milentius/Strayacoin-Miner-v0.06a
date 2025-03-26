using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    /// <summary>
    /// Class for drawing ASCII tables with a bar in the middle.
    /// </summary>
    public class WithBar
    {
        private readonly AsciiTableDrawer _drawer;
        private readonly int _padding;
        private readonly ConsoleColor _borderColor;
        private readonly ConsoleColor _textColor;
        private readonly TextAlignment _textAlignment;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithBar"/> class.
        /// </summary>
        /// <param name="drawer">The parent AsciiTableDrawer instance.</param>
        /// <param name="padding">Padding inside the table cells.</param>
        /// <param name="borderColor">Color of the table borders.</param>
        /// <param name="textColor">Color of the text inside the table.</param>
        /// <param name="alignment">Text alignment within the table cells.</param>
        public WithBar(AsciiTableDrawer drawer, int padding, ConsoleColor borderColor, ConsoleColor textColor, TextAlignment alignment)
        {
            _drawer = drawer;
            _padding = padding;
            _borderColor = borderColor;
            _textColor = textColor;
            _textAlignment = alignment;
        }

        /// <summary>
        /// Writes a line of text with the specified color.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="newLine">Whether to write a new line after the text.</param>
        public void WriteLineWithColor(string text, ConsoleColor color, bool newLine = true)
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

        /// <summary>
        /// Creates a separator line with the specified character.
        /// </summary>
        /// <param name="separatorChar">The character to use for the separator.</param>
        /// <param name="isWithBar">Whether the separator includes a bar in the middle.</param>
        /// <returns>A string representing the separator line.</returns>
        public string CreateSeparator(char separatorChar, bool isWithBar)
        {
            int tableWidth = _drawer.TableWidth;
            if (!isWithBar)
                return $"█{new string(separatorChar, tableWidth - 2)}█";

            int halfWidth = (tableWidth - 3) / 2;
            return $"█{new string(separatorChar, halfWidth)}█{new string(separatorChar, halfWidth)}█";
        }

        /// <summary>
        /// Draws the top border of the table.
        /// </summary>
        /// <param name="newLine">Whether to write a new line after the border.</param>
        public void DrawTopBorder(bool newLine = true)
        {
            WriteLineWithColor(CreateSeparator('▀', true), _borderColor, newLine);
        }

        /// <summary>
        /// Draws the bottom border of the table.
        /// </summary>
        /// <param name="newLine">Whether to write a new line after the border.</param>
        public void DrawBottomBorder(bool newLine = true)
        {
            WriteLineWithColor(CreateSeparator('▄', true), _borderColor, newLine);
        }

        /// <summary>
        /// Draws a row with a bar in the middle, separating left and right text.
        /// </summary>
        /// <param name="leftText">The text to display on the left side of the bar.</param>
        /// <param name="rightText">The text to display on the right side of the bar.</param>
        /// <param name="newLine">Whether to write a new line after the row.</param>
        public void DrawRowWithBar(string leftText, string rightText, bool newLine = true)
        {
            int tableWidth = _drawer.TableWidth;
            int halfWidth = (tableWidth - 3) / 2; // Divide table width into two sections
            int leftPadding = (halfWidth - leftText.Length) / 2; // Adjust for border and bar
            int rightPadding = (halfWidth - rightText.Length) / 2; // Adjust for border and bar

            // Ensure padding is not negative
            leftPadding = Math.Max(0, leftPadding);
            rightPadding = Math.Max(0, rightPadding);

            // Construct the left and right sections
            string left = $"{new string(' ', leftPadding)}{leftText}{new string(' ', halfWidth - leftPadding - leftText.Length)}";
            string right = $"{new string(' ', rightPadding)}{rightText}{new string(' ', halfWidth - rightPadding - rightText.Length)}";

            // Write the row
            Console.ForegroundColor = _borderColor;
            Console.Write("█"); // Left border

            // Write the left section
            Console.ForegroundColor = _textColor;
            Console.Write(left);

            // Write the middle bar
            Console.ForegroundColor = _borderColor;
            Console.Write("█");

            // Write the right section
            Console.ForegroundColor = _textColor;
            Console.Write(right);

            // Write the right border
            Console.ForegroundColor = _borderColor;
            if (newLine)
            {
                Console.WriteLine("█");
            }
            else
            {
                Console.Write("█");
            }

            // Reset colors
            Console.ResetColor();
        }
    }
}
