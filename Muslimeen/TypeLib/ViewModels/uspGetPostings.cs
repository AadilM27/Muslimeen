using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetPostings
    {
        public int PostID { get; set; }
        public string PostContent { get; set; }
        public DateTime PostCreateDate { get; set; }
        public string PostCreateName { get; set; }
        public int ForumTopicID { get; set; }
    }
}
