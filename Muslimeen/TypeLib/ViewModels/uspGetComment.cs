using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetComment
    {
        public int ArticleID { get; set; }
        public string CommentMessage { get; set; }
        public DateTime CommentDate { get; set; }
        public string Name { get; set; }
    }
}
