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
            
            timesheetMain1.completeListOfDataToRender.Add(sampleData1);
            timesheetMain1.completeListOfDataToRender.Add(sampleData2);
            timesheetMain1.completeListOfDataToRender.Add(sampleData3);

            timesheetMain1.prepareRendering();
            timesheetMain1.Refresh();
        }
    }
}
