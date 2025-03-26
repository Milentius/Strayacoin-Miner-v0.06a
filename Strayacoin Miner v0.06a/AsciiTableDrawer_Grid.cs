using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    /// <summary>
    /// Class for drawing ASCII grid tables.
    /// </summary>
    public class Grid
    {
        private readonly int _tableWidth;
        private readonly int _padding;
        private readonly ConsoleColor _borderColor;
        private readonly ConsoleColor _textColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        /// <param name="tableWidth">Width of the table.</param>
        /// <param name="padding">Padding inside the table cells.</param>
        /// <param name="borderColor">Color of the table borders.</param>
        /// <param name="textColor">Color of the text inside the table.</param>
        public Grid(int tableWidth, int padding, ConsoleColor borderColor, ConsoleColor textColor)
        {
            _tableWidth = tableWidth;
            _padding = padding;
            _borderColor = borderColor;
            _textColor = textColor;
        }

        /// <summary>
        /// Writes text with the specified color.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="newLine">Whether to write a new line after the text.</param>
        private void WriteWithColor(string text, ConsoleColor color, bool newLine = true)
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
        /// Creates a row border with the specified cell width and number of columns.
        /// </summary>
        /// <param name="cellWidth">Width of each cell.</param>
        /// <param name="columns">Number of columns.</param>
        /// <returns>A string representing the row border.</returns>
        private string CreateRowBorder(int cellWidth, int columns)
        {
            string cellBorder = "█" + new string('▀', cellWidth);
            return string.Join("", Enumerable.Repeat(cellBorder, columns)) + "█";
        }

        /// <summary>
        /// Creates a row bottom border with the specified cell width and number of columns.
        /// </summary>
        /// <param name="cellWidth">Width of each cell.</param>
        /// <param name="columns">Number of columns.</param>
        /// <returns>A string representing the row bottom border.</returns>
        private string CreateRowBottomBorder(int cellWidth, int columns)
        {
            string cellBorder = "█" + new string('▄', cellWidth);
            return string.Join("", Enumerable.Repeat(cellBorder, columns)) + "█";
        }

        /// <summary>
        /// Draws a grid with single-character data.
        /// </summary>
        /// <param name="data">The data to display in the grid.</param>
        /// <param name="newLine">Whether to write a new line after each row.</param>
        public void CreateGridSingleChar(char[][] data, bool newLine = true)
        {
            int rows = data.Length;
            int columns = data[0].Length; // Assuming all rows have the same number of columns
            int cellWidth = 5; // Fixed cell width for single-character data (includes padding)

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                // Draw top border for the current row
                WriteWithColor(CreateRowBorder(cellWidth, columns), _borderColor, newLine);

                // Draw cells in the current row
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    WriteWithColor("█", _borderColor, false);

                    WriteWithColor($"  {data[rowIndex][colIndex]}  ", _textColor, false);
                }
                WriteWithColor("█", _borderColor, newLine); // Close the row

                // Draw bottom border for the current row
                WriteWithColor(CreateRowBottomBorder(cellWidth, columns), _borderColor, newLine);
            }
        }

        /// <summary>
        /// Creates a row border with the specified column widths.
        /// </summary>
        /// <param name="columnWidths">Array of column widths.</param>
        /// <returns>A string representing the row border.</returns>
        private string CreateRowBorder(int[] columnWidths)
        {
            string border = string.Join("", columnWidths.Select(width => "█" + new string('▀', width)));
            return border + "█";
        }

        /// <summary>
        /// Creates a row bottom border with the specified column widths.
        /// </summary>
        /// <param name="columnWidths">Array of column widths.</param>
        /// <returns>A string representing the row bottom border.</returns>
        private string CreateRowBottomBorder(int[] columnWidths)
        {
            string border = string.Join("", columnWidths.Select(width => "█" + new string('▄', width)));
            return border + "█";
        }

        /// <summary>
        /// Draws a grid with multi-character data.
        /// </summary>
        /// <param name="data">The data to display in the grid.</param>
        /// <param name="newLine">Whether to write a new line after each row.</param>
        public void CreateGridMultiChar(string[][] data, bool newLine = true)
        {
            int rows = data.Length;
            int columns = data[0].Length; // Assuming all rows have the same number of columns

            // Determine the maximum width needed for each column
            int[] columnWidths = new int[columns];
            for (int col = 0; col < columns; col++)
            {
                columnWidths[col] = data.Max(row => row[col].Length) + 2; // Add 2 for padding
            }

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                // Draw top border for the current row
                WriteWithColor(CreateRowBorder(columnWidths), _borderColor, newLine);

                // Draw cells in the current row
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    WriteWithColor("█", _borderColor, false);

                    string cellData = data[rowIndex][colIndex];
                    string paddedData = cellData.PadLeft((columnWidths[colIndex] + cellData.Length) / 2)
                                               .PadRight(columnWidths[colIndex]);
                    WriteWithColor(paddedData, _textColor, false);
                }
                WriteWithColor("█", _borderColor, newLine); // Close the row

                // Draw bottom border for the current row
                WriteWithColor(CreateRowBottomBorder(columnWidths), _borderColor, newLine);
            }
        }
    }
}
