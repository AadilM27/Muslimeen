using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    class Comment
    {
        public int CommentID { get; set; }
        public int ContentID { get; set; }
        public DateTime DateTimeCommented { get; set; }
        public int? CommentRating { get; set; }
        public string MemberID { get; set; }
        public string CommentContent { get; set; }
    }
}
