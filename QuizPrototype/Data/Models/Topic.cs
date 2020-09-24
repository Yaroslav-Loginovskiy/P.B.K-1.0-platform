using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Data.Models
{
  public class Topic
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public List<Topic> SubTopic { get; set; }
        public int TopicId { get; set; }


    }
}
