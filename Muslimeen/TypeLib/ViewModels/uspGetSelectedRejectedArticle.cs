using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetSelectedRejectedArticle
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime DateCreated { get; set; }
        public string RejectionReason { get; set; }
        public int TopicID { get; set; }
    }
}
