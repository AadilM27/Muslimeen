using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string WebsiteAddress { get; set; }
        public string Image { get; set; } //should be Byte[] but used string for compatibility of data type.
        public string ContactNo { get; set; }
        public string PhysicalAddress { get; set; }
        public char Active { get; set; }
    }
}
