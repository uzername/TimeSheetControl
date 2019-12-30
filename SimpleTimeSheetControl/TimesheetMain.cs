using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheetControl.SimpleTimeSheetControl
{
    public partial class TimesheetMain : UserControl
    {
        public List<InputDataClass> completeListOfDataToRender = null;
        /// <summary>
        /// font, used to render data into 1st column of table
        /// </summary>
        public Font InscriptionFont;
        /// <summary>
        /// width of first column
        /// </summary>
        private int desiredwdth = 0;
        /// <summary>
        /// total height of control
        /// </summary>
        private int desiredheight = 0;
        public TimesheetMain()  {
            InitializeComponent();
            // set font later
            InscriptionFont = new Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        }
        /// <summary>
        /// call this every time you have updated InscriptionFont or completeListOfDataToRender (just anything inside it)
        /// </summary>
        public void prepareRendering()
        {
            if (completeListOfDataToRender == null) return;
            
            // https://stackoverflow.com/questions/4759646/how-to-manually-get-instance-of-graphics-object-in-winforms
            Graphics contextGraphics = realDrawingPanel.CreateGraphics();
            foreach (var item in completeListOfDataToRender)  {
                int foundWidth = MeasureDisplayStringWidth(contextGraphics, item.Name,InscriptionFont);
                if (foundWidth < desiredwdth)
                {
                    desiredwdth = foundWidth;
                }
                desiredheight += InscriptionFont.Height + 5;
            }
            realDrawingPanel.Width = Parent.Width;
            realDrawingPanel.Height = desiredheight;
        }
        // https://www.codeproject.com/Articles/2118/Bypass-Graphics-MeasureString-limitations
        static private int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, 1000, 1000);
            System.Drawing.CharacterRange[] ranges = { new System.Drawing.CharacterRange(0,text.Length) };
            System.Drawing.Region[] regions = new System.Drawing.Region[1];
            format.SetMeasurableCharacterRanges(ranges);

            regions = graphics.MeasureCharacterRanges(text, font, rect, format);
            rect = regions[0].GetBounds(graphics);

            return (int)(rect.Right + 1.0f);
        }

        private void RealDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, desiredwdth, 0, desiredwdth, this.realDrawingPanel.Height);
        }
    }
}
