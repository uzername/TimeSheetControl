using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSheetControl.SimpleTimeSheetControl;

namespace TimeSheetControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timesheetMain1.completeListOfDataToRender = new List<InputDataClass>();
            InputDataClass sampleData1 = new InputDataClass { Name= "Itha Canaamiya" };
            sampleData1.allTimes.Add(new InputTimingInterval(new DateTime(2019, 11, 01, 09, 10, 11), new DateTime(2019, 11, 01, 10, 00, 00)));
            sampleData1.allTimes.Add(new InputTimingInterval(new DateTime(2019, 11, 01, 10, 10, 15), new DateTime(2019, 11, 01, 10, 30, 00)));
            InputDataClass sampleData2 = new InputDataClass { Name = "Vadane Elathialu" };
            sampleData2.allTimes.Add(new InputTimingInterval(new DateTime(2019, 11, 01, 08, 06, 11), new DateTime(2019, 11, 01, 12, 03, 00)));
            sampleData2.allTimes.Add(new InputTimingInterval(new DateTime(2019, 11, 01, 12, 10, 15), new DateTime(2019, 11, 01, 13, 30, 00)));
            sampleData2.allTimes.Add(new InputTimingInterval(new DateTime(2019, 11, 01, 14, 10, 45), new DateTime(2019, 11, 01, 15, 55, 00)));
            InputDataClass sampleData3 = new InputDataClass { Name = "Iwo Daleeagle" };
            InputDataClass sampleData4 = new InputDataClass { Name = "Clarke" };
            InputDataClass sampleData5 = new InputDataClass { Name = "Pointy Magicevans" };
            InputDataClass sampleData6 = new InputDataClass { Name = "Grubby Hansen" };
            InputDataClass sampleData7 = new InputDataClass { Name = "Greenmedina Orness" };
            InputDataClass sampleData8 = new InputDataClass { Name = "Wine Chapower" };
            InputDataClass sampleData9 = new InputDataClass { Name = "Druan Reynor" };
            InputDataClass sampleData10 = new InputDataClass { Name = "Harrisonow Kendbyrne" };
            InputDataClass sampleData11 = new InputDataClass { Name = "Dob Jackson" };
            InputDataClass sampleData12 = new InputDataClass { Name = "Dorothy Shepard" };
            InputDataClass sampleData13 = new InputDataClass { Name = "Sheldon Mackie" };
            InputDataClass sampleData14 = new InputDataClass { Name = "Ned Texas" };
            InputDataClass sampleData15 = new InputDataClass { Name = "Cheryl Samuels" };
            
            timesheetMain1.completeListOfDataToRender.Add(sampleData1);
            timesheetMain1.completeListOfDataToRender.Add(sampleData2);
            timesheetMain1.completeListOfDataToRender.Add(sampleData3);
            timesheetMain1.completeListOfDataToRender.Add(sampleData4);
            timesheetMain1.completeListOfDataToRender.Add(sampleData5);
            timesheetMain1.completeListOfDataToRender.Add(sampleData6);
            timesheetMain1.completeListOfDataToRender.Add(sampleData7);
            timesheetMain1.completeListOfDataToRender.Add(sampleData8);
            timesheetMain1.completeListOfDataToRender.Add(sampleData9);
            timesheetMain1.completeListOfDataToRender.Add(sampleData10);
            timesheetMain1.completeListOfDataToRender.Add(sampleData11);
            timesheetMain1.completeListOfDataToRender.Add(sampleData12);
            timesheetMain1.completeListOfDataToRender.Add(sampleData13);
            timesheetMain1.completeListOfDataToRender.Add(sampleData14);
            timesheetMain1.completeListOfDataToRender.Add(sampleData15);
            timesheetMain1.InscriptionFont = new Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            timesheetMain1.recalculateFirstColumnSize = true;

            timesheetMain1.Refresh();
        }
    }
}
