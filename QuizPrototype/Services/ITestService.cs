using QuizPrototype.Data.Models;

namespace QuizPrototype.Services
{
    public interface ITestService
    {
        //  List<Test> GetAllTests();
        void TakeTest();
        void UpdateTest(int id, Test newTest);
        // void DeleteTest(int id);
        void AddTest();
    }
}
