﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TypeLib.Models
{
    public class Rating
    { 
        public string MemberID { get; set; }
        public int ArticleID { get; set; }
        public int rating { get; set; }
    }
}
