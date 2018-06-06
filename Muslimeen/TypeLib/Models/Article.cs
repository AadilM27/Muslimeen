﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime DateCeated { get; set; }
        public char Status { get; set; }
        public string RejectionReason { get; set; }
        public char Active { get; set; }
        public string RemovalReason { get; set; }
        public string ScholarID { get; set; }
        public string ModeratorID { get; set; }
        public int TopicID {get;set;}
    }
}
