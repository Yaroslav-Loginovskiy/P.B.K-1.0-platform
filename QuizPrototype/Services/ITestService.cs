using QuizPrototype.Data.Models;

namespace QuizPrototype.Services
{
    public interface ITestService
    {

        void TakeTest();
        void UpdateTest(int id, Test newTest);
    }
}
