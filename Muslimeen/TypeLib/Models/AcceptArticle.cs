﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class AcceptArticle
    {
        public int ArticleID { get; set; }
        public string ModeratorID { get; set; }
        public char Status { get; set; }
        public char Active { get; set; }
       
    }
}
