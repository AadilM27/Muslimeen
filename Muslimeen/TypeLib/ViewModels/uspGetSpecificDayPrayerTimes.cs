using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
   public  class uspGetSpecificDayPrayerTimes
    {
        public DateTime PrayerDate { get; set; }
        public string PrayerDay { get; set; }
        public string FajrA { get; set; }
        public string FajrJ { get; set; }
        public string DhuhrA { get; set; }
        public string DhuhrJ { get; set; }
        public string AsrA { get; set; }
        public string AsrJ { get; set; }
        public string MagribA { get; set; }
        public string MagribJ { get; set; }
        public string EishaA { get; set; }
        public string EishaJ { get; set; }
    }
}
