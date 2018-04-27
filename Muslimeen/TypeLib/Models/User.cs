using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public DateTime UserDate { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }
        public string Active { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int MosqueID { get; set; }
    }
}
