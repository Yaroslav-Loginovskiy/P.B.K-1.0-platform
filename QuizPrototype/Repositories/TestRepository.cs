using QuizPrototype.Data.Models;
using QuizPrototype.Data.Models.Data;
using System.Collections.Generic;

namespace QuizPrototype.Repositories
{
    public class TestRepository
    {

        public List<Test> GetAllTests()
        {

            List<Test> alltests = Tests.allTests;
            return alltests;
        }

        public void AddTest(Test newTest)
        {

            Tests.allTests.Add(newTest);
        }



    }
}
