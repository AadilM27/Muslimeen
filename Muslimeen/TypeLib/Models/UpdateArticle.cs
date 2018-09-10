using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class UpdateArticle
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public int ArticleTopic { get; set; }
        public char Status { get; set; }
        public char Active { get; set; }
        public string ScholarID { get; set; }
    }
}
