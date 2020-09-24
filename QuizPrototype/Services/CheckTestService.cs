using System;

namespace QuizPrototype.Services
{
    public class CheckTestService
    {

        public bool CheckAnswer(string userAnswer, string rightAnswer)
        {
            bool result;
      
            if (userAnswer.ToLowerInvariant() == rightAnswer.ToLowerInvariant())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public Func<int, int, bool> CheckTest = (positive, negative) => positive > negative ? true : false;
       
    }
}
