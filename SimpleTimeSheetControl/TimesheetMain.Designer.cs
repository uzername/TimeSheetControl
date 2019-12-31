namespace TimeSheetControl.SimpleTimeSheetControl
{
    partial class TimesheetMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.realDrawingPanel = new TimeSheetControl.SimpleTimeSheetControl.MyPanelForDrawing();
            this.SuspendLayout();
            // 
            // realDrawingPanel
            // 
            this.realDrawingPanel.Location = new System.Drawing.Point(0, 0);
            this.realDrawingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.realDrawingPanel.Name = "realDrawingPanel";
            this.realDrawingPanel.Size = new System.Drawing.Size(493, 264);
            this.realDrawingPanel.TabIndex = 0;
            this.realDrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RealDrawingPanel_Paint);
            this.realDrawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.realDrawingPanel_MouseDown);
            this.realDrawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.realDrawingPanel_MouseMove);
            this.realDrawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.realDrawingPanel_MouseUp);
            // 
            // TimesheetMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.realDrawingPanel);
            this.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TimesheetMain";
            this.Size = new System.Drawing.Size(682, 396);
            this.ResumeLayout(false);

        }

        #endregion

        public MyPanelForDrawing realDrawingPanel;
    }
}
