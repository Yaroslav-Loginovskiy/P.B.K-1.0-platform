using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;

namespace QuizPrototype.UI
{
    public class UserPrompts
    {

        TestRepository TestRepository = new TestRepository();
        readonly ITestRepository _repository;

        public UserPrompts()
        {

        }
        public UserPrompts(ITestRepository repository)
        {
            _repository = repository;
        }

        public Test PromptForTargetTestId()
        {
            bool isExisting = false;

            Test test = null;

            do
            {


                List<Test> allTests = _repository.GetAllTests();

                int count = 0;
                foreach (var testItem in allTests)
                {
                    count++;
                    Console.WriteLine($"{testItem.Id}) Test title : {testItem.Title}\n Test description: {testItem.Description} \n Test sub-theme: {testItem.SubTheme} \n");
                }


                bool isParsedId;
                int testId;
                do
                {

                    Console.WriteLine("Choose the number of test u want to take...");


                    isParsedId = int.TryParse(Console.ReadLine(), out testId);
                    if (isParsedId == false)
                    {
                        Console.WriteLine("Please, enter a number");
                    }

                } while (isParsedId != true);

                var userTest = TestRepository.GetTestById(testId);
                if (userTest == null) { Console.WriteLine("!!!This id doesn't exist!!!\n"); isExisting = false; }
                else { isExisting = true; test = userTest; }

            } while (isExisting == false);
            return test;
        }
        public int PromptsForUpdatingTestById()
        {
            bool isExisting = false;
            int testId;
            bool isParsedId = false;
            do
            {

                List<Test> allTests = _repository.GetAllTests();

                int count = 0;
                foreach (var itemTest in allTests)
                {
                    count++;
                    Console.WriteLine($"{itemTest.Id}) Test title : {itemTest.Title}\n Test description: {itemTest.Description} \n Test sub-theme: {itemTest.SubTheme} \n");
                }

                do
                {


                    Console.WriteLine("Choose the number of test u want to update...");


                    isParsedId = int.TryParse(Console.ReadLine(), out testId);
                    if (isParsedId == false)
                    {
                        Console.WriteLine("Please, enter a number\n");
                    }
                } while (isParsedId != true);
                var oldTest = TestRepository.GetTestById(testId);
                if (oldTest == null) { Console.WriteLine("!!!This id doesn't exist!!!\n"); isExisting = false; }
                else { isExisting = true; }


            } while (isExisting == false);
            return testId;
        }
    }
}
