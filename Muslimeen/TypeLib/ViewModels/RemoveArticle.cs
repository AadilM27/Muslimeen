using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class RemoveArticle
    {
        public int ArticleID { get; set; }
        public char Status { get; set; }
        public string RemovalReason { get; set; }
        public char Active { get; set; }
        public string ModeratorID { get; set; }
    }
}
