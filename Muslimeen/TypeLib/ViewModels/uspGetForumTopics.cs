using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLib.ViewModels
{
    public class uspGetForumTopics
    {
        public int ForumTopicID { get; set; }
        public string TopicSubject { get; set; }
        public DateTime TopicCreateDate { get; set; }
        public string TopicCreateName { get; set; }
    }
}
