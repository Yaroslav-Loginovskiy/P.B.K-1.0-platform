using QuizPrototype.Data.Models;
using QuizPrototype.Services;
using System;

namespace QuizPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            TestService service = new TestService();
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
                "3)Change test\n ");

            int userChoise;
            string Userline;
            bool parsed;

            do
            {
                /* // Возвращает true, если хотя бы один из операндов возвращает true. */
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
                        if ((userChoise > 3 || userChoise < 1))
                        {
                            Console.WriteLine("Incorrect number, try a different");
                        }
                    }
                }

            } while (!parsed || (userChoise > 3 || userChoise < 1));

            
           


                switch (userChoise)
                {
                    case 1:
                         service.TakeTest();
                        break;
                    case 2:
                        //Create a new Test.
                        service.AddTest();

                        break;
                    case 3:
                        //TestRepository.UpdateTest();  
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
                    if (userEnter =="n")
                    {
                        userAnsw = true;
                    }
                    else
                    {
                        Console.WriteLine("Uncorrect enter");
                    }
                }
            } while (userAnsw != false);
            //Console.ReadKey();

        }
    }
}
