using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Services
{
   public class CheckTestService
    {
        bool result;
        
        public bool CheckTest(string question, string answer)
        {
            if (question.ToLower() == answer.ToLower())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
