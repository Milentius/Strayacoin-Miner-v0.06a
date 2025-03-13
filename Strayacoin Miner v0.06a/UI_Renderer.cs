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

        public void RenderUI() 
        {
            
            // Fourth Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawTopBorder(false);              atd.TableWidth = 20; atd.DrawTopBorder(false);              atd.TableWidth = 10; atd.DrawTopBorder(false);                  atd.TableWidth = 10; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                atd.TableWidth = 20; atd.DrawRow("", false);                atd.TableWidth = 10; atd.DrawRow("", false);                    atd.TableWidth = 10; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawBottomBorder(false);           atd.TableWidth = 20; atd.DrawBottomBorder(false);           atd.TableWidth = 10; atd.DrawBottomBorder(false);               atd.TableWidth = 10; atd.DrawBottomBorder(true);

            // Second Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);              atd.TableWidth = 20; atd.DrawTopBorder(false);              atd.TableWidth = 20; atd.DrawTopBorder(false);                  atd.TableWidth = 50; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);                atd.TableWidth = 20; atd.DrawRow("", false);                atd.TableWidth = 20; atd.DrawRow("", false);                    atd.TableWidth = 50; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);           atd.TableWidth = 20; atd.DrawBottomBorder(false);           atd.TableWidth = 20; atd.DrawBottomBorder(false);               atd.TableWidth = 50; atd.DrawBottomBorder(true);

            // Third Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 40; atd.DrawTopBorder(false);              atd.TableWidth = 30; atd.DrawTopBorder(false);             atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 40; atd.DrawRow("", false);                atd.TableWidth = 30; atd.DrawRow("", false);               atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 40; atd.DrawBottomBorder(false);           atd.TableWidth = 30; atd.DrawBottomBorder(false);          atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Fourth Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawTopBorder(false);                                                                          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Fifth Row                                                                                                                                                                                                                                                                              
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Sixth Row                                                                                                                                                                                                                                                                            
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Seventh Row                                                                                                                                                                                                                                                                             
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);

        }

        public void OLD_RenderUI(
            string Title,
            string infoSlot_R1C1,
            string infoSlot_R1C2,
            string infoSlot_R1C3,
            string infoSlot_R1C4,
            string infoSlot_R2C1,
            string infoSlot_R2C2,
            string infoSlot_R2C3,
            string infoSlot_R2C4,
            string infoSlot_R2C5,
            string infoSlot_R2C6

            )
        {
            // First Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);                          atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 30; atd.DrawTopBorder(false);          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow($"{infoSlot_R1C1}", false);            atd.TableWidth = 40; atd.DrawRow($"{infoSlot_R1C2}", false);    atd.TableWidth = 30; atd.DrawRow($"{infoSlot_R1C3}", false);            atd.TableWidth = 40; atd.DrawRow($"{infoSlot_R1C4}", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);                       atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 30; atd.DrawBottomBorder(false);       atd.TableWidth = 40; atd.DrawBottomBorder(true);

            // Second Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 50; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow($"{infoSlot_R2C1}", false);            atd.TableWidth = 20; atd.DrawRow($"{infoSlot_R2C2}", false);            atd.TableWidth = 20; atd.DrawRow($"{infoSlot_R2C4}", false);            atd.TableWidth = 20; atd.DrawRow($"{infoSlot_R2C5}", false);            atd.TableWidth = 50; atd.DrawRow($"{infoSlot_R2C6}", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 50; atd.DrawBottomBorder(true);

            // Third Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 50; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 50; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 50; atd.DrawBottomBorder(true);

            // Fourth Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawTopBorder(false);          atd.TableWidth = 20; atd.DrawTopBorder(false);          atd.TableWidth = 10; atd.DrawTopBorder(false);          atd.TableWidth = 10; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);            atd.TableWidth = 20; atd.DrawRow("", false);            atd.TableWidth = 10; atd.DrawRow("", false);            atd.TableWidth = 10; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawBottomBorder(false);       atd.TableWidth = 20; atd.DrawBottomBorder(false);       atd.TableWidth = 10; atd.DrawBottomBorder(false);       atd.TableWidth = 10; atd.DrawBottomBorder(true);

            // Fifth Row
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawTopBorder(false);                                                                                                                          atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Sixth Row                                                                                                                                                                                                                   
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Seventh Row                                                                                                                                                                                                                 
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Eighth Row                                                                                                                                                                                                                  
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Ninth Row                                                                                                                                                                                                                   
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Tenth Row                                                                                                                                                                                                                   
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Eleventh Row                                                                                                                                                                                                                
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
                                                                                                                                                                                                                                           
            // Twelfth Row                                                                                                                                                                                                                 
            atd.TableWidth = 40; atd.DrawTopBorder(false);          atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawTopBorder(true);
            atd.TableWidth = 40; atd.DrawRow("", false);            atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawRow("", true);
            atd.TableWidth = 40; atd.DrawBottomBorder(false);       atd.TableWidth = 70; atd.DrawRow("", false);                                                                                                                            atd.TableWidth = 40; atd.DrawBottomBorder(true);
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
