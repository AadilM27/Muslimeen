using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
   public class uspGetMosqueEventsDateRange
    {
        public int EventID { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string EventTitle { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public string Speaker { get; set; }
    }
}
