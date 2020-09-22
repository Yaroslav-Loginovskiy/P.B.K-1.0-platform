using QuizPrototype.Data;
using QuizPrototype.Data.Models;
using System;
using System.Linq;
using System.Timers;

namespace QuizPrototype.Services
{
    public class TestService
    {

        readonly CheckTestService checkService = new CheckTestService();
        //TODO: IUserRepository _userRepository
        // _userRepository.Tests.AddNewTest();
        System.Timers.Timer timer;
        Test _test;
        UserTest userTest;
        bool testFinished;
        TimeSpan currentTestTime = default;
        //_repository.AddTest() 

        public TestService(Test test)
        {
            _test = test;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            userTest = new UserTest();

        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            currentTestTime += new TimeSpan(0, 0, 1);

            if (_test.Time == currentTestTime)
            {
                Console.WriteLine("Your test is finished");
                testFinished = true;
            }
        }

        //Stopwatch - total time
        //System.Timers.Timer - with events

        public bool TakeTest(bool resultsAreVisible = false)
        {
            Console.WriteLine($"You selected test about {_test.Title}, sub-theme of this test is: {_test.SubTheme}\n ");
            if (_test.Time.Hours != 0 || _test.Time.Minutes != 0 || _test.Time.Seconds != 0)
            {
                Console.WriteLine("This test include timer");
                Console.WriteLine($" You have {_test.Time.Hours} hours , {_test.Time.Minutes} minutes , {_test.Time.Seconds} seconds to pass this test.");
            }
            else
            {
                Console.WriteLine("This test doesn't include timer");
            }
            Console.WriteLine("Do you want to see results after every question? y/n");
            string userAnsw;
            do
            {

                userAnsw = Console.ReadLine();
                if (userAnsw == "y")
                {
                    resultsAreVisible = true;
                }
                else
                {
                    if (userAnsw == "n")
                    {
                        resultsAreVisible = false;
                    }
                    else
                    {
                        Console.WriteLine("Uncorrect enter");
                    }
                }
            } while (userAnsw != "n" & userAnsw != "y");
            currentTestTime = default;
            timer.Start();
            int positive = default;
            int negative = default;
            int remainingQuestionsCount = _test.Questions.Count;
            int i = 0;

            while (remainingQuestionsCount == 0 || i != remainingQuestionsCount)

            {
                //CHECK
                var question = _test.Questions.ElementAt(i);
              //  var question = _test.Questions.Where(x => x.Id == i).FirstOrDefault();
                    


  

               i++;

                Console.WriteLine($"Question is :{question.Body}\n");
                Console.WriteLine("Please, write the answer...");

                var userAnswer = Console.ReadLine();

                if (testFinished == true)
                {
                    Console.WriteLine("Sorry you can't submit questions");
                    testFinished = false;
                    return checkService.CheckTest(positive, negative);

                }

                bool isCorrectAnswer = checkService.CheckAnswer(userAnswer, question.Answer.Body );

                if (isCorrectAnswer)
                {
                    if (resultsAreVisible) Console.WriteLine($"You're right, answer is:{question.Answer.Body}");
                    positive++;
                }
                else
                {
                    if (resultsAreVisible) Console.WriteLine($"Wrong answer, the right answer is: {question.Answer.Body}");
                    negative++;
                }
            }
            timer.Stop();
            return checkService.CheckTest(positive, negative);
        }

        /* 
         * public bool TakeTest(int testId, )
         * 
         * 
         */
    }


}
