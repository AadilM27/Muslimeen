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
        public string OrgName { get; set; }
        public string Address { get; set; }
        public string OrgImageUrl { get; set; }
    }
}
