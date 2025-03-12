using Ascii_Table_Drawer;
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

        public UI_Renderer(AsciiTableDrawer ATD)
        {
            atd = ATD;
        }

        public void RenderUI(string Title)
        {
            // First Row
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 30; atd.DrawRow($"{Title}", false);            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Second Row
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Third Row
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Fourth Row
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 10; atd.DrawTopBorder(false);          atd.TableWidth = 10; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 10; atd.DrawRow("", false);            atd.TableWidth = 10; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 10; atd.DrawBottomBorder(false);       atd.TableWidth = 10; atd.DrawBottomBorder(true);

            // Fifth Row
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawTopBorder(false);                                                                                                                          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Sixth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Seventh Row                                                                                                                                                                                                                 
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Eighth Row                                                                                                                                                                                                                  
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Ninth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Tenth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Eleventh Row                                                                                                                                                                                                                
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Twelfth Row                                                                                                                                                                                                                 
            atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false);            atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 60; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
        }

        public void RenderUI_1to4()
        {
            // First Row
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Second Row
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Third Row
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Fourth Row
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawTopBorder(false); atd.TableWidth = 20; atd.DrawTopBorder(false); atd.TableWidth = 10; atd.DrawTopBorder(false); atd.TableWidth = 10; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 20; atd.DrawRow("", false); atd.TableWidth = 10; atd.DrawRow("", false); atd.TableWidth = 10; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawBottomBorder(false); atd.TableWidth = 20; atd.DrawBottomBorder(false); atd.TableWidth = 10; atd.DrawBottomBorder(false); atd.TableWidth = 10; atd.DrawBottomBorder(true);
        }

        public void RenderUI_5to9()
        {
            // Fifth Row
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawTopBorder(false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Sixth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Seventh Row                                                                                                                                                                                                                 
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Eighth Row                                                                                                                                                                                                                  
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Ninth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", true);
        }

        public void RenderUI_10to12()
        {
            // Tenth Row                                                                                                                                                                                                                   
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Eleventh Row                                                                                                                                                                                                                
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Twelfth Row                                                                                                                                                                                                                 
            atd.TableWidth = 30; atd.DrawTopBorder(false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 30; atd.DrawRow("", false); atd.TableWidth = 60; atd.DrawRow("", false); atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 30; atd.DrawBottomBorder(false); atd.TableWidth = 60; atd.DrawRow("", false);
        }

        public void TEST_RenderVisualBlockUI()
        {
            // Experimental Visual Blocks Layout
            atd.TableWidth = 130; atd.DrawTopBorder(true);
            atd.TableWidth = 130; atd.DrawRow("█ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █", true);
            atd.TableWidth = 130; atd.DrawRow("", true);
            atd.TableWidth = 130; atd.DrawRow("", true);
            atd.TableWidth = 130; atd.DrawBottomBorder(true);
        }
    }
}
