using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspViewLatestArticles
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public string Names { get; set; }
    }
}
