using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Threading;

namespace QuizPrototype.Services
{
   public class TestService : ITestService
    {
        readonly TestRepository testRepository = new TestRepository();
        readonly CheckTestService checkService = new CheckTestService();
       
        public void AddTest()
        {
            Test test = new Test();
            test.Questions = new List<Question>();
            test.Answers = new List<Answer>();
            Console.WriteLine("*** Creating Test ***");
            test.Id = 4;
            Console.WriteLine("Enter a title");
            test.Title = Console.ReadLine();
            Console.WriteLine("Enter a Subtheme");
            test.SubTheme = Console.ReadLine();
            Console.WriteLine("Enter a description");
            test.Description = Console.ReadLine();
            Console.WriteLine("Enter a sub sub theme");
            test.SubSubTheme = Console.ReadLine();
            bool userAnsw = true;
            do
            {
                Console.WriteLine("Please add a question in your test...");
                test.Questions.Add(new Question { question = Console.ReadLine() });

                Console.WriteLine("Please, add a answer to the question below...");
                test.Answers.Add(new Answer { answer = Console.ReadLine() });
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
            foreach (var answer in test.Answers)
            {
               Console.WriteLine(answer.answer);
            }
        }

       
        public void TakeTest()
        {
            List<Test> allTests = testRepository.GetAllTests();
            int count = 0;
            foreach (var test in allTests)
            {
                count++;
                Console.WriteLine($"{count}) Test title : {test.Title}\n Test description: {test.Description} \n Test sub-theme: {test.SubTheme} \n");
            }

            Console.WriteLine("Choose the number of test u want to take...");

            // Check input here!
            int userEnter = int.Parse(Console.ReadLine());
            // !!!

            // decrement user enter, because of list starts with 0 index.
            userEnter--;
            var selectedTest = allTests.Where(x => x.Id == userEnter).FirstOrDefault();
            //TakeTestWithTimer(selectedTest);
            Thread thread = new Thread(new ParameterizedThreadStart(TakeTestWithTimer));
            thread.Start(selectedTest);
            Thread thread2 = new Thread(new ParameterizedThreadStart(TimerService.StartTimer));
            thread2.Start(selectedTest.Timer);
            do
            {
                if (!thread.IsAlive)
                {
                    selectedTest.Timer = 0;
                    thread2.Start(selectedTest);
                }
                else
                {
                    if (!thread2.IsAlive)
                    {
                        selectedTest.accept = false;
                        
                        thread.Start(selectedTest);

                    }
                }

            } while (thread.IsAlive || thread2.IsAlive);
            Console.WriteLine("You did it.");

            //TakeTestWithTimer(selectedTest);
            //  TimerService.StartTimer(selectedTest.Timer);
            //bool isCompleted = TakeTestWithTimer(selectedTest);
            //do
            //{
            //    if (isCompleted ==true)
            //    {
            //        TimerService.StartTimer(0);
            //    }
            //} while (true);



            //bool  running_ = false;
            // thread.Interrupt();
            //  if (!thread.Join(2000))
            //  { // or an agreed resonable time
            //     thread.Abort();
            //  }



           
           

        }

        public void UpdateTest(int id, Test newTest)
        {
            throw new NotImplementedException();
        }

        public void TakeTestWithTimer(Object obj)
        {
            var selectedTest = (Test)obj;
            
            if (selectedTest.accept)
            {
                Console.WriteLine($"You selected test about {selectedTest.Title}, sub-theme of this test is: {selectedTest.SubTheme}\n ");
                List<Question> questions = selectedTest.Questions.ToList();
                List<Answer> answers = selectedTest.Answers.ToList();
                bool result;
                for (int i = 0; i < questions.Count; i++)
                {
                    var question = questions.ElementAt(i);
                    var answer = answers.ElementAt(i);
                    Console.WriteLine($"Question is :{question.question}\n");
                    Console.WriteLine("Please, write the answer...");
                    var userAnswer = Console.ReadLine();
                    result = checkService.CheckTest(userAnswer, answer.answer);
                    if (result == true)
                    {
                        Console.WriteLine($"You're right, answer is:{answer.answer}");
                    }
                    else
                    {
                        Console.WriteLine($"Wrong answer, the right answer is: {answer.answer}");
                    }
                }
            }
            
  
            

        }
    }
}
