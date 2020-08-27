using QuizPrototype.Data.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Data.Models
{
   public class Test
    {
        public int id { get; set; }
        public string title { get; set; }

        public List<Tests> tests { get; set; }
        public string description { get; set; }
        public string subTheme { get; set; }
        public string subSubTheme { get; set; }
        public List<Question> questions { get; set; }
        public List<Answer> answers { get; set; }
        public int timer { get; set; }
    }
}
