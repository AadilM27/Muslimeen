using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.Models
{
    public class ForumTopics
    {
        public int ForumTopicID { get; set; }
        public string TopicSubject { get; set; }
        public DateTime TopicCreateDate { get; set; }
        public string TopicCreateName { get; set; }
    }
}
