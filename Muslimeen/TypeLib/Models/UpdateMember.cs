using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class UpdateMember
    {
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int? MosqueID { get; set; }
    }
}
