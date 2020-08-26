using QuizPrototype.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
