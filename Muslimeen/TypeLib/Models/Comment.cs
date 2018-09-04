﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Comment
    {
        public int? CommentID { get; set; }
        public int ArticleID { get; set; }
        public string MemberID { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentMessage {get;set;}
    }
}
