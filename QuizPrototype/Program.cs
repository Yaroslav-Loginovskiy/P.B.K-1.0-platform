using QuizPrototype.Data;
using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using QuizPrototype.Services;
using QuizPrototype.UI;
using System;

namespace QuizPrototype
{
    class Program
    {
        static void Main(string[] args)
        {

            ITestRepository testRepository = new TestRepository();
            UserPrompts userPrompts = new UserPrompts(testRepository);
            //DataBaseContext dataBaseContext = new DataBaseContext();
            //User user = new User();
            //user.Name = "guest";
            
            
            //dataBaseContext.User.Add(user);
            //dataBaseContext.SaveChanges();
            //TestService testService = new TestService();
            Console.WriteLine("***Welcome to PBK 1.0 test platform!***\n");
            Console.WriteLine(@"In this application you can:

             *Take tests
             *Create tests
             *Change tests
             ");
            var userAnsw = true;
            do
            {
                Console.WriteLine("Please, enter the following number:\n" +
                "1)Take test\n" +
                "2)Create test\n" +
                "3)Change test\n" +
                "4)Show statistics\n ");

                int userChoise;
                string Userline;
                bool parsed;

                do
                {
                    /* || Возвращает true, если хотя бы один из операндов возвращает true. */
                    Userline = Console.ReadLine();
                    parsed = int.TryParse(Userline, out userChoise);
                    if (string.IsNullOrWhiteSpace(Userline))
                    {
                        Console.WriteLine("!!!Alert!!!\n Empty input, please choose something");
                    }
                    else
                    {
                        if (!parsed)
                        {
                            Console.WriteLine($"!!!Alert!!!\n {Userline} is not a number, please, try again..");
                        }
                        else
                        {
                            if ((userChoise > 4 || userChoise < 1))
                            {
                                Console.WriteLine("Incorrect number, try a different");
                            }
                        }
                    }

                } while (!parsed || (userChoise > 4 || userChoise < 1));

                switch (userChoise)
                {
                    case 1:

                        int testIdD = userPrompts.PromptForTargetRandomTestId();
                        var test = testRepository.GetTestById(testIdD);
                        TestService service = new TestService(test);
                        service.TakeTest();
                        break;
                    case 2:
                        var newTest = Test.CreateTest();
                        testRepository.AddTest(newTest);


                        break;
                    case 3:
                        var testId = userPrompts.PromptsForUpdatingTestById();
                        var updatedTest = Test.UpdateTest(testId);
                        testRepository.UpdateTest(updatedTest);

                        break;
                    case 4:
                        Console.WriteLine("Showing statistics...");
                        Console.ReadLine();
                        break;

                }
                Console.WriteLine("Exit from programm? y/n");
                var userEnter = Console.ReadLine();
                if (userEnter == "y")
                {
                    userAnsw = false;
                }
                else
                {
                    if (userEnter == "n")
                    {
                        userAnsw = true;
                    }
                    else
                    {
                        Console.WriteLine("Uncorrect enter");
                    }
                }
            } while (userAnsw != false);

        }


    }
}
