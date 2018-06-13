using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetMosquePrayerTimes
    {
        public string PrayerDescription { get; set; }
        public DateTime PrayerDate { get; set; }
        public string PrayerDay { get; set; }
        public string AdhaanTime { get; set; }
        public string JamaatTime { get; set; }
    }
}
