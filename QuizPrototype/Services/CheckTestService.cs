namespace QuizPrototype.Services
{
    public class CheckTestService
    {
        public bool CheckTest(string userAnswer, string answer)
        {
            bool result;
            if (userAnswer.ToLower() == answer.ToLower())
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
