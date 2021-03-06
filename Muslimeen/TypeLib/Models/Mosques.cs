﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class Mosques
    {
        public int MosqueID { get; set; }
        public string MosqueName { get; set; }
        public string MosqueStreet { get; set; }
        public string MosqueSuburb { get; set; }
        public DateTime YearEstablished { get; set; }
        public string MosqueType { get; set; }
        public char Active { get; set; }
        public string MosqueImage { get; set; }
        public string MosqueSize { get; set; }
        public string MosqueQuote { get; set; }
    }
}
