using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime MemberDOB { get; set; }
        public string Password { get; set; }
        public string MemberType { get; set; }
        public string Active { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int MosqueID { get; set; }
    }
}
