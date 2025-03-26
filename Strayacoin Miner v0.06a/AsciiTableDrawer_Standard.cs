using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    /// <summary>
    /// Class for drawing standard ASCII tables.
    /// </summary>
    public class Standard
    {
        private readonly int _tableWidth;
        private readonly int _padding;
        private readonly ConsoleColor _borderColor;
        private readonly ConsoleColor _textColor;
        private readonly TextAlignment _textAlignment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Standard"/> class.
        /// </summary>
        /// <param name="tableWidth">Width of the table.</param>
        /// <param name="padding">Padding inside the table cells.</param>
        /// <param name="borderColor">Color of the table borders.</param>
        /// <param name="textColor">Color of the text inside the table.</param>
        /// <param name="alignment">Text alignment within the table cells.</param>
        public Standard(int tableWidth, int padding, ConsoleColor borderColor, ConsoleColor textColor, TextAlignment alignment)
        {
            _tableWidth = tableWidth;
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
        private void WriteLineWithColor(string text, ConsoleColor color, bool newLine = true)
        {
            int contentWidth = _tableWidth - 2; // Exclude borders
            string formattedText;

            // Apply alignment
            switch (_textAlignment)
            {
                case TextAlignment.Left:
                    formattedText = text.PadRight(contentWidth); // Align to the left
                    break;
                case TextAlignment.Center:
                    int padding = Math.Max((contentWidth - text.Length) / 2, 0);
                    formattedText = new string(' ', padding) + text + new string(' ', Math.Max(contentWidth - text.Length - padding, 0));
                    break;
                case TextAlignment.Right:
                    formattedText = text.PadLeft(contentWidth); // Align to the right
                    break;
                default:
                    formattedText = text.PadRight(contentWidth); // Fallback to left alignment
                    break;
            }

            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(formattedText);
            }
            else
            {
                Console.Write(formattedText);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Creates a separator line with the specified character.
        /// </summary>
        /// <param name="separatorChar">The character to use for the separator.</param>
        /// <returns>A string representing the separator line.</returns>
        public string CreateSeparator(char separatorChar)
        {
            return $"█{new string(separatorChar, _tableWidth - 2)}█";
        }

        /// <summary>
        /// Draws the top border of the table.
        /// </summary>
        /// <param name="newLine">Whether to write a new line after the border.</param>
        public void DrawTopBorder(bool newLine = true)
        {
            WriteLineWithColor(CreateSeparator('▀'), _borderColor, newLine);
        }

        /// <summary>
        /// Draws the bottom border of the table.
        /// </summary>
        /// <param name="newLine">Whether to write a new line after the border.</param>
        public void DrawBottomBorder(bool newLine = true)
        {
            WriteLineWithColor(CreateSeparator('▄'), _borderColor, newLine);
        }

        /// <summary>
        /// Draws a row with the specified text.
        /// </summary>
        /// <param name="text">The text to display in the row.</param>
        /// <param name="newLine">Whether to write a new line after the row.</param>
        public void DrawRow(string text, bool newLine = true)
        {
            int contentWidth = _tableWidth - 4 - _padding * 2; // Account for borders and padding
            string alignedText;

            // Apply alignment
            switch (_textAlignment)
            {
                case TextAlignment.Left:
                    alignedText = text.PadRight(contentWidth); // Align to the left
                    break;
                case TextAlignment.Center:
                    int padding = Math.Max((contentWidth - text.Length) / 2, 0);
                    alignedText = new string(' ', padding) + text + new string(' ', Math.Max(contentWidth - text.Length - padding, 0));
                    break;
                case TextAlignment.Right:
                    alignedText = text.PadLeft(contentWidth); // Align to the right
                    break;
                default:
                    alignedText = text.PadRight(contentWidth); // Fallback to left alignment
                    break;
            }

            // Draw left border in border color
            Console.ForegroundColor = _borderColor;
            Console.Write("█ ");

            // Draw text in text color
            Console.ForegroundColor = _textColor;
            Console.Write(new string(' ', _padding) + alignedText + new string(' ', _padding));

            // Draw right border in border color
            Console.ForegroundColor = _borderColor;
            if (newLine)
            {
                Console.WriteLine(" █");
            }
            else
            {
                Console.Write(" █");
            }

            // Reset the color for subsequent operations
            Console.ResetColor();
        }

        /// <summary>
        /// Draws an empty row.
        /// </summary>
        /// <param name="newLine">Whether to write a new line after the row.</param>
        public void DrawEmptyRow(bool newLine = true)
        {
            // Calculate the content width based on table width and padding
            int contentWidth = _tableWidth - 4 - _padding * 2; // Exclude left/right borders and padding

            // Construct the empty row
            string emptyContent = new string(' ', contentWidth); // Completely empty space for the content
            string row = $"█ {new string(' ', _padding)}{emptyContent}{new string(' ', _padding)} █";

            // Write the row
            WriteLineWithColor(row, _borderColor, newLine);
        }
    }
}
