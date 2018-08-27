using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Postings
    {
        public int PostID { get; set; }
        public string PostContent { get; set; }
        public DateTime PostCreateDate { get; set; }
        public string PostCreateName { get; set; }
        public int ForumTopicID { get; set; }
    }
}
