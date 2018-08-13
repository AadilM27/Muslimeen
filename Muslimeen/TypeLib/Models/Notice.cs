using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Notice
    {
        public int NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeDescription { get; set; }
        public string MemberID{get; set;}
        public DateTime DateCreated { get; set; }
        public DateTime DateExpiry { get; set; }
        public char Active { get; set; }   
    }
}
