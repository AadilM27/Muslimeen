using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class uspAddZakaahOrg
    {   
        public string Name { get; set; }
        public string WebsiteAddress { get; set; }
        public byte[] Image { get; set; }
        public string ContactNo { get; set; }
        public string PhysicalAddress { get; set; }
        public char Active { get; set; }

    }
}
