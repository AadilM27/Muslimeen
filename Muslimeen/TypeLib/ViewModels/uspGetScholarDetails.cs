﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetScholarDetails
    {
        public string ScholarID { get; set; }
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public string ContactNo { get; set; }
        public DateTime MemberDOB { get; set; }
        public string Email { get; set; }
        public char MemberType { get; set; }
        public char ActiveTypeID { get; set; }
        public string QualificationDescription { get; set; }
        public int? MosqueID { get; set; }
        public DateTime ActivationExpiry { get; set; }
        public DateTime ActivationDate { get; set; }
        public string Password { get; set; }
    }
}
