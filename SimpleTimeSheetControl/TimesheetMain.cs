using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace TimeSheetControl.SimpleTimeSheetControl
{

    public partial class TimesheetMain : UserControl
    {
        /// <summary>
        /// list of data to render
        /// </summary>
        public List<InputDataClass> completeListOfDataToRender = null;
        /// <summary>
        /// Value of True indicates that size of first column will be recalculated to fit content once we reach draw event
        /// After that value will be flipped to false
        /// </summary>
        public bool recalculateFirstColumnSize = false; 
        private bool nowDraggingFirstColumn = false; //indicates that we are dragging now separator of first column
        private int separatorLocationFirstColumn = 0; // position on X where to draw the separator. 
        private Pen separatorFirstColumn = new Pen(Color.Black, 1.0f); // style for line which separates first column
        private Pen separatorRows = new Pen(Color.DarkGray, 1.0f); // style for rows separator
        private Pen separatorFirstColumnDragged = new Pen(Color.SlateGray, 2.0f);
        
        /// <summary>
        /// font, used to render data into 1st column of table
        /// </summary>
        public Font InscriptionFont;
        /// <summary>
        /// width of first column
        /// </summary>
        public int desiredwdth = 0;
        /// <summary>
        /// height of texts in control
        /// </summary>
        public int desiredheight = 0;
        public TimesheetMain() {
            InitializeComponent();
            // set font later
            InscriptionFont = new Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            separatorRows.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.realDrawingPanel.Width = this.Width-2;
            
        }

        // https://www.codeproject.com/Articles/2118/Bypass-Graphics-MeasureString-limitations
        static private int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, 1000, 1000);
            System.Drawing.CharacterRange[] ranges = { new System.Drawing.CharacterRange(0, text.Length) };
            System.Drawing.Region[] regions = new System.Drawing.Region[1];
            format.SetMeasurableCharacterRanges(ranges);

            regions = graphics.MeasureCharacterRanges(text, font, rect, format);
            rect = regions[0].GetBounds(graphics);

            return (int)(rect.Right + 1.0f);
        }

        private void RealDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (completeListOfDataToRender == null) { return; }
            float desiredY = -InscriptionFont.Height;
            foreach (var item in completeListOfDataToRender)
            {
                if (recalculateFirstColumnSize) {
                    int foundWidth = MeasureDisplayStringWidth(e.Graphics, item.Name, InscriptionFont);
                    if (foundWidth > desiredwdth) {
                        desiredwdth = foundWidth;
                    }
                    desiredheight += InscriptionFont.Height + 6;
                }
                 desiredY += InscriptionFont.Height + 6;
                e.Graphics.DrawString(item.Name, InscriptionFont, Brushes.Black, 0.0f, desiredY);
                
            }
            if (recalculateFirstColumnSize)   {
                int maxValue = desiredheight;
                if (maxValue<this.realDrawingPanel.Height)  {
                    maxValue = this.realDrawingPanel.Height-2;
                } 
                if (maxValue<this.Height)
                {
                    maxValue = this.Height-2;
                }

                this.realDrawingPanel.Height = maxValue;
                recalculateFirstColumnSize = false;
            }

            e.Graphics.DrawLine(separatorFirstColumn, desiredwdth, 0, desiredwdth, this.realDrawingPanel.Height); // draw separator of first column
            //are we dragging now separator of first column? draw it!
            if (nowDraggingFirstColumn)
            {
                e.Graphics.DrawLine(separatorFirstColumnDragged, separatorLocationFirstColumn, 0, separatorLocationFirstColumn, this.realDrawingPanel.Height);
            }

            //draw horizontal lines at end
            for (int iii=1; iii <= completeListOfDataToRender.Count; iii++)  {
                e.Graphics.DrawLine(separatorRows,0.0f,iii*(InscriptionFont.Height + 6),this.realDrawingPanel.Width, iii * (InscriptionFont.Height + 6));
            }
        }

        private void realDrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            
            if ((e.X >= desiredwdth-3)&& (e.X <= desiredwdth + 3))  {
                this.Cursor = Cursors.SizeWE;
            } else {
                if (e.Button == MouseButtons.None)
                    this.Cursor = Cursors.Default;
                else if (nowDraggingFirstColumn)  {
                    this.Cursor = Cursors.SizeWE;
                    this.separatorLocationFirstColumn = e.X;
                    realDrawingPanel.Refresh();
                }
            }
        }

        private void realDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X >= desiredwdth - 3) && (e.X <= desiredwdth + 3))
            {
                nowDraggingFirstColumn = true;
                this.separatorLocationFirstColumn = e.X;
            }
        }

        private void realDrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (nowDraggingFirstColumn)
            {
                nowDraggingFirstColumn = false;
                desiredwdth = e.X;
                this.realDrawingPanel.Refresh();
            }
        }
    }
    public class MyPanelForDrawing : Panel
    {
        public MyPanelForDrawing()
        {
            this.DoubleBuffered = true;
        }
    }
}
