using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class uspUpdateMemberActiveStatus
    {
        public string MemberID { get; set; }
        public char ActiveTypeID { get; set; }
        public char MemberType { get; set; }
    }
}
