using QuizPrototype.Data.Models.Data;
using System;
using QuizPrototype.Data;

using System.Collections.Generic;
using System.Text;
using QuizPrototype.Data.Models;

namespace QuizPrototype.Repositories
{
    public class TestRepository
    {
        Tests tests = new Tests();
        public List<Test> GetAllTests()
        {
            
            List<Test> alltests = tests.allTests;
            return alltests;
        }

        public void AddTest(Test newTest)
        {
            
            tests.allTests.Add(newTest);
        }
        
        

    }
}
