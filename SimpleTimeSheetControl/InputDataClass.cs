using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetControl.SimpleTimeSheetControl
{
   public class InputTimingInterval
    {
        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }
        public InputTimingInterval(DateTime time1, DateTime time2)  {
            if (time1<time2) {
                startTime = time1; endTime = time2;
            } else {
                startTime = time2; endTime = time1;
            }
        }
    }
   public class InputDataClass {
        public String Name;
        public List<InputTimingInterval> allTimes = new List<InputTimingInterval>();
    }
}
