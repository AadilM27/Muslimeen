using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class uspAddMosque
    {
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime MemberDOB { get; set; }
        public string Password { get; set; }
        public char MemberType {get;set;}
        public char ActiveTypeID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime? ActivationExpiry { get; set; }
        public DateTime ActivationDate { get; set; }
        public string MosqueName { get; set; }
        public string MosqueStreet { get; set; }
        public string MosqueSuburb { get; set; }
        public string MosqueType { get; set; }
        public byte[] MosqueImage { get; set; }
        public string MosqueSize { get; set; }
        public string MosqueQuote { get; set; }
        public DateTime? YearEstablished { get; set; }
    }
}
