using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Linq;
using System.Timers;

namespace QuizPrototype.Services
{
    public class TestService
    {

        readonly CheckTestService checkService = new CheckTestService();
        IUserRepository _userRepository = new UserRepository();
        System.Timers.Timer timer;
        Test _test;
        bool testFinished;
        TimeSpan currentTestTime = default;

        public TestService(Test test)
        {
            _test = test;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
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
            User _user = _userRepository.GetUserById(1);
            UserTest userTest = new UserTest();
            userTest.UserName = _user.Name;
            userTest.TestId = _test.Id;



            Console.WriteLine($"You selected test about {_test.Title}, topic of this test is: {_test.Topic}\n ");
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

                var question = _test.Questions.ElementAt(i);
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

                bool isCorrectAnswer = checkService.CheckAnswer(userAnswer, question.Answer.Body);

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
            Console.WriteLine("*Test ended*");
            Console.WriteLine($"Count of wrong questions: {negative}");
            Console.WriteLine($"Count of right Answers:{positive}");

            _test.RightQuestionsCount = positive;
            _test.WrongQiestionsCount = negative;
            TestRepository testRepository = new TestRepository();
            testRepository.UpdateTest(_test);
            _userRepository.SaveNewUserTest(userTest);
            return checkService.CheckTest(positive, negative);

        }

    }
}
