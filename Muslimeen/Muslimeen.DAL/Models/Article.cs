using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muslimeen.DAL.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string ArticleHeading { get; set; }
        public string ArticleAttachments { get; set; }
        public string ArticleContent { get; set; }

    }
}
