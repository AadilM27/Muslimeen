using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    class Content
    {
        public int ContentID { get; set; }
        public int TopicID { get; set; }
        public DateTime DateCreated { get; set; }
        public string ContentType { get; set; }
        public string ContentStatus { get; set; }
        public string ContentRejectionReason { get; set; }
        public string ContentRemovalReason { get; set; }
        public string Active { get; set; }
        public string ScholarID{ get;set;}
        public int? moderatorID { get; set; }
    }
}
