using System;
using System.Collections.Generic;

namespace QuizPrototype.Data.Models
{
    public class UserTest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int TestId { get; set; }

       public List<Answer> RightAnswers { get; set; }
        public List<Answer> WrongAnswers { get; set;}


    }
}
