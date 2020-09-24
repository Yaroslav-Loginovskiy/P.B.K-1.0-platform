using System.Collections.Generic;
using QuizPrototype.Data.Models;

namespace QuizPrototype.Repositories
{
    public interface ITestRepository
    {
        void AddTest(Test newTest);
        List<Test> GetAllTests();
        Test GetTestById(int id);
        void UpdateTest(Test test);
        List<Topic> GetAllTopics();
        int GetRandomTestByTopic(string topic);

    }
}