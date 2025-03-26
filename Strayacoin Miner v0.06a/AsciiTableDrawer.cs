using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strayacoin_Miner_v0._06a
{
    public class AsciiTableDrawer
    {
        // Properties common to all table types
        public int TableWidth { get; set; }
        public int Padding { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public TextAlignment Alignment { get; set; }

        // Constructor
        public AsciiTableDrawer(int tableWidth, int padding, ConsoleColor borderColor, ConsoleColor textColor, TextAlignment alignment)
        {
            TableWidth = tableWidth;
            Padding = padding;
            BorderColor = borderColor;
            TextColor = textColor;
            Alignment = alignment;
        }

        // Subclasses
        public Standard StandardDrawer => new Standard(TableWidth, Padding, BorderColor, TextColor, Alignment);
        public WithBar WithBarDrawer => new WithBar(this, Padding, BorderColor, TextColor, Alignment);
        public Grid GridDrawer => new Grid(TableWidth, Padding, BorderColor, TextColor);
        public Extras ExtrasDrawer => new Extras(TableWidth, Padding, BorderColor, TextColor);
        public Custom WindowDrawer => new Custom(TableWidth, Padding, BorderColor, TextColor);
    }


    // Enum for TextAlignment
    public enum TextAlignment
    {
        Left,
        Center,
        Right
    }

}

