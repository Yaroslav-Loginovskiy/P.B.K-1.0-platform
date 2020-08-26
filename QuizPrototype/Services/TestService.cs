using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using QuizPrototype.Data.Models.Data;

namespace QuizPrototype.Services
{
    public class TestService : ITestService
    {
        TestRepository testRepository = new TestRepository();
        public void AddTest()
        {
            
            Test test = new Test();
            test.questions = new List<Question>();
            test.answers = new List<Answer>();
           // test.tests = new List<Tests>();
            Console.WriteLine("*** Creating Test ***");
            test.id = 4;
            Console.WriteLine("Enter a title");
            test.title = Console.ReadLine();
            Console.WriteLine("Enter a Subtheme");
            test.subTheme = Console.ReadLine();
            Console.WriteLine("Enter a description");
            test.description = Console.ReadLine();
            Console.WriteLine("Enter a sub sub theme");
            test.subSubTheme = Console.ReadLine();
            bool userAnsw = true;
            do
            {
                Console.WriteLine("Please add a question in your test...");

                test.questions.Add(new Question { question = Console.ReadLine() });

                Console.WriteLine("Please, add a answer to the question below...");

                test.answers.Add(new Answer { answer = Console.ReadLine() });
                Console.WriteLine("Do you want to create one more question? y/n");
                
                do
                {
                    var userEnter = Console.ReadLine();
                    if (userEnter.ToLower() == "y")
                    {
                        userAnsw = true;
                        break;
                    }
                    else
                    {
                        if (userEnter.ToLower() == "n")
                        {
                            Console.WriteLine("***Congratulations! You have created your Test!***");
                            userAnsw = false;
                        }
                        else
                        {
                            Console.WriteLine("Please,enter 'y' or 'n' to continue...");
                            userAnsw = true;
                        }

                    }

                    
                } while (userAnsw == true);


            } while (userAnsw == true);


            testRepository.AddTest(test);
            //Console.WriteLine($"Title of your Test : {test.title}\n Description of your test: {test.description}\n Sub-theme of your test: {test.subTheme}\n sub-sub theme of your test: {test.subSubTheme}" +
            //    $"  ");
            foreach (var answer in test.answers)
            {
               
                Console.WriteLine(answer.answer);
            }


            
        }

        //public void DeleteTest(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Test> GetAllTests()
        //{
        //    throw new NotImplementedException();
        //}

        public void TakeTest()
        {
            
            List<Test> alltests = testRepository.GetAllTests();
            int count = 0;

            //var selected = from t in alltests select t;

            foreach (var test in alltests)
            {

                count++;
                Console.WriteLine($"{count}) Test title : {test.title}\n Test description: {test.description} \n Test sub-theme: {test.subTheme} \n");
            }

            Console.WriteLine("Choose the number of test u want to take...");

            // Сделать тут проверку на ввод!
            int userEnter = int.Parse(Console.ReadLine());
            // !!!

            var selectedTest = alltests.Where(x => x.id == userEnter).FirstOrDefault();
            Console.WriteLine($"You selected test about {selectedTest.title}, sub-theme of this test is: {selectedTest.subTheme} ");
            do
            {


            } while (true);
        }

        public void UpdateTest(int id, Test newTest)
        {
            throw new NotImplementedException();
        }
    }
}
