using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{

    public class Extras
    {
        private readonly int _tableWidth;
        private readonly int _padding;
        private readonly ConsoleColor _borderColor;
        private readonly ConsoleColor _textColor;
        public List<(ConsoleColor color, int confirmations)> _blockStates;

        public Extras(int tableWidth, int padding, ConsoleColor borderColor, ConsoleColor textColor)
        {
            _tableWidth = tableWidth;
            _padding = padding;
            _borderColor = borderColor;
            _textColor = textColor;
            _blockStates = new List<(ConsoleColor, int)>();
        }

        public void CreateMenu()
        {
            // Logic for Menus
        }

        public void FileBrowser()
        {
            // Logic for FileBrowser
        }

        public void VisualBlockIndicator(bool transactionFound)
        {
            Console.Clear();
            UpdateBlockStates(transactionFound);
            DrawIndicator();
        }

        private void UpdateBlockStates(bool transactionFound)
        {
            if (transactionFound)
            {
                _blockStates.Add((ConsoleColor.Yellow, 0));
            }
            else
            {
                _blockStates.Add((ConsoleColor.White, -1));
            }

            for (int i = 0; i < _blockStates.Count; i++)
            {
                if (_blockStates[i].confirmations >= 0)
                {
                    _blockStates[i] = (_blockStates[i].confirmations switch
                    {
                        0 => ConsoleColor.Blue,
                        1 => ConsoleColor.Green,
                        _ => _blockStates[i].color
                    }, _blockStates[i].confirmations + 1);
                }
            }
        }

        private void DrawIndicator()
        {
            DrawBorder('▀');
            int blocksPerRow = (_tableWidth - 2 * _padding - 2) / 2;
            for (int i = 0; i < _blockStates.Count; i++)
            {
                if (i % blocksPerRow == 0)
                {
                    if (i > 0)
                    {
                        Console.Write(new string(' ', _padding));
                        Console.ForegroundColor = _borderColor;
                        Console.Write("█");
                        Console.ResetColor();
                        Console.WriteLine();
                        DrawEmptyRow();
                    }
                    Console.ForegroundColor = _borderColor;
                    Console.Write("█");
                    Console.ResetColor();
                    Console.Write(new string(' ', _padding));
                }
                Console.BackgroundColor = _blockStates[i].color;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
            }

            // Fill the remaining space in the last row
            int remainingBlocks = blocksPerRow - (_blockStates.Count % blocksPerRow);
            if (remainingBlocks != blocksPerRow)
            {
                Console.Write(new string(' ', remainingBlocks * 2));
                Console.Write(new string(' ', _padding));
                Console.ForegroundColor = _borderColor;
                Console.Write("█");
                Console.ResetColor();
            }

            Console.WriteLine();
            DrawBorder('▄');
        }

        private void DrawBorder(char borderChar)
        {
            Console.ForegroundColor = _borderColor;
            Console.WriteLine($"█{new string(borderChar, _tableWidth - 2)}█");
            Console.ResetColor();
        }

        private void DrawEmptyRow()
        {
            Console.ForegroundColor = _borderColor;
            Console.Write("█");
            Console.ResetColor();
            Console.Write(new string(' ', _tableWidth - 2));
            Console.ForegroundColor = _borderColor;
            Console.WriteLine("█");
            Console.ResetColor();
        }
    }
}


