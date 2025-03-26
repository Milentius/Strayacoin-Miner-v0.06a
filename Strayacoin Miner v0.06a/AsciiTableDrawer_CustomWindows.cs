using Mono.Unix.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Strayacoin_Miner_v0._06a
{

    public class Custom
    {
        private readonly int _tableWidth;
        private readonly int _padding;
        private readonly ConsoleColor _borderColor;
        private readonly ConsoleColor _textColor;

        public Custom(int tableWidth, int padding, ConsoleColor borderColor, ConsoleColor textColor)
        {
            _tableWidth = tableWidth;
            _padding = padding;
            _borderColor = borderColor;
            _textColor = textColor;
        }


        // this function will be used as a base function, we will use several other functions to pass the 'content' to this function
        public void DrawWindow(int width, int height, string title, string[] content)
        {
            DrawTitleBar(title);
            
            
            
            
        }

        private void DrawTitleBar(string text)
        {
            string topBorder = "█" + new string('▀', _tableWidth - 2) + "█";
            int padding = (_tableWidth - 4 - text.Length) / 2;
            string textRow1 = "▀█" + new string(' ', padding) + text + new string(' ', _tableWidth - 4 - text.Length - padding) + "█▀";
            string textRow2 = " █" + new string('▄', _tableWidth - 4) + "█ ";
            string bottomBorder = "▄█" + new string(' ', _tableWidth - 4) + "█▄";
            
            Console.WriteLine(topBorder);
            Console.WriteLine(textRow1);
            Console.WriteLine(textRow2);
            Console.WriteLine(bottomBorder);
        }

        public void DrawWindowContent_SingleRow(string Line1)
        {
            Console.WriteLine(CreateRowContent(Line1));
            
            //int padding = (_tableWidth - 2 - Line1.Length) / 2;
            //string textRow = "█" + new string(' ', padding) + Line1 + new string(' ', _tableWidth - 4 - Line1.Length - padding) + "█";
            //
            //Console.WriteLine(textRow);
        }

        public void DrawWindowContent_doubleRow(string Line1, string Line2)
        {
            Console.WriteLine(CreateRowContent(Line1));
            Console.WriteLine(CreateRowContent(Line2));
            //int paddingRow1 = (_tableWidth - 2 - Line1.Length) / 2;
            //string textRowRow1 = "█" + new string(' ', paddingRow1) + Line1 + new string(' ', _tableWidth - 4 - Line1.Length - paddingRow1) + "█";
            //
            //int paddingRow2 = (_tableWidth - 2 - Line2.Length) / 2;
            //string textRowRow2 = "█" + new string(' ', paddingRow2) + Line2 + new string(' ', _tableWidth - 4 - Line2.Length - paddingRow2) + "█";
            //
            //Console.WriteLine(textRowRow1);
            //Console.WriteLine(textRowRow2);
        }

        public void DrawWindowContent_TripleRow(string Line1, string Line2, string Line3)
        {
            Console.WriteLine(CreateRowContent(Line1));
            Console.WriteLine(CreateRowContent(Line2));
            Console.WriteLine(CreateRowContent(Line3));
            //int paddingRow1 = (_tableWidth - 2 - Line1.Length) / 2;
            //string textRowRow1 = "█" + new string(' ', paddingRow1) + Line1 + new string(' ', _tableWidth - 4 - Line1.Length - paddingRow1) + "█";
            //
            //int paddingRow2 = (_tableWidth - 2 - Line2.Length) / 2;
            //string textRowRow2 = "█" + new string(' ', paddingRow2) + Line2 + new string(' ', _tableWidth - 4 - Line2.Length - paddingRow2) + "█";
            //
            //int paddingRow3 = (_tableWidth - 2 - Line3.Length) / 2;
            //string textRowRow3 = "█" + new string(' ', paddingRow3) + Line3 + new string(' ', _tableWidth - 4 - Line3.Length - paddingRow3) + "█";
            //
            //Console.WriteLine(textRowRow1);
            //Console.WriteLine(textRowRow2);
            //Console.WriteLine(textRowRow3);
        }

        // Helper Function to create row content
        private string CreateRowContent(string content)
        {
            int padding = (_tableWidth - 2 - content.Length) / 2;
            string textRow = "█" + new string(' ', padding) + content + new string(' ', _tableWidth - 4 - content.Length - padding) + "█";
            return textRow;
        }
    }
}


