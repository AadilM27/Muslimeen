using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    class Prayer
    { 
        public int PrayerID { get; set; }
        public int MosqueID { get; set; }
        public DateTime Date { get; set; }
        public string PrayerType { get; set; }
    }
}
