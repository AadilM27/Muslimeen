using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspReportGetAllMembers
    {
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime MemberDOB { get; set; }
        public char MemberType { get; set; }
        public char ActiveTypeID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int? MosqueID { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
