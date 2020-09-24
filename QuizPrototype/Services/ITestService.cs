using QuizPrototype.Data.Models;
using System.Collections.Generic;

namespace QuizPrototype.Services
{
    public interface ITestService
    {
        //  List<Test> GetAllTests();
        void TakeTest();
        void UpdateTest(int id, Test newTest);
        // void DeleteTest(int id);    
        
    }
}
