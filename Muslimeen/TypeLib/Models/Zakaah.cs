using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Zakaah
    {
        public int ZakaahID { get; set; }
        public string ZakaahDesc { get; set; }
        public string ZakaahConditions { get; set; }
        public string CalculationDesc { get; set; }
        public string ZakaahPermissible { get; set; }
        public string CautionsOfZakaah { get; set; }
        public string AssetsOfZakaah { get; set; }
        public string ApplicableZakaah { get; set; }

    }
}
