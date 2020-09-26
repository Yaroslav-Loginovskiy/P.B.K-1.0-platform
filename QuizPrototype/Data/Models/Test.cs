using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace QuizPrototype.Data.Models
{
    public class Test
    {
        //TODO: Introduce pass trashold

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }



        public string Topic { get; set; }

        public List<Question> Questions { get; set; }
        public TimeSpan Time { get; set; }

        public int RightQuestionsCount { get; set; }

        public int WrongQiestionsCount { get; set; }

        public static Test CreateTest()
        {
            Test test = new Test();

            test.Questions = new List<Question>();

            Console.WriteLine("*** Creating Test ***");

            Console.WriteLine("Enter a title");
            test.Title = Console.ReadLine();

            Console.WriteLine("Enter a description");
            test.Description = Console.ReadLine();

            Console.WriteLine("There is a topics you can choose...\n");
            Topic topic = null;
            do
            {


                TreeStructureTopics treeStructure = new TreeStructureTopics();
                treeStructure.GetTreeTopic();
                Console.WriteLine("Choose the one of them and write name of topic below...");

                string topicName = Console.ReadLine();
                var existingTopic = treeStructure.GetTopicName(topicName);
                if (existingTopic == null)
                {
                    Console.WriteLine("!Please, write the name one of topics given below!\n" +
                        $"----Uncurrect topic '{topicName}'");
                }
                topic = existingTopic;
            } while (topic == null);

            test.Topic = topic.Name;
            string isTimerExist;
            Console.WriteLine("Do you want to have a timer in your test? y/n");
            do
            {
                isTimerExist = Console.ReadLine();
                if (isTimerExist.ToLower() == "y")
                {

                    int timerHours;
                    int timerMinutes;
                    int timerSeconds;
                    string userTime;
                    int userParsedTime;
                    bool isConverted;
                    do
                    {
                        Console.WriteLine("Please, enter a hours");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerHours = userParsedTime;
                    do
                    {
                        Console.WriteLine("Please, enter a minutes");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerMinutes = userParsedTime;
                    do
                    {
                        Console.WriteLine("Please, enter a seconds");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerSeconds = userParsedTime;
                    test.Time = new TimeSpan(timerHours, timerMinutes, timerSeconds);
                    break;
                }
                else
                {
                    if (isTimerExist.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please,enter 'y' or 'n' to continue...");
                    }
                }
            } while (isTimerExist != "y" & isTimerExist != "no");

            bool userAnsw = true;
            do
            {
                Console.WriteLine("Please add a question in your test...");
                string userQuestion = Console.ReadLine();


                Console.WriteLine("Please, add a answer to the question below...");

                string answerToUserQuestion = Console.ReadLine();
                test.Questions.Add(new Question()
                {
                    Body = userQuestion,
                    Answer = new Answer { Body = answerToUserQuestion }
                });

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

            return test;
        }


        public static Test UpdateTest(int testId)
        {
            TestRepository testRepository = new TestRepository();
            Test updatedtest = testRepository.GetTestById(testId);

            Console.WriteLine("***Test updating***\n");

            Console.WriteLine("Please, enter a new title");
            string newTitle = Console.ReadLine();
            updatedtest.Title = newTitle;





            Console.WriteLine("Please, enter a new description");
            string newDescription = Console.ReadLine();
            updatedtest.Description = newDescription;

            Console.WriteLine("There are available topics, that you can choose.\n");
            TreeStructureTopics treeStructureTopics = new TreeStructureTopics();

            Topic topic = null;

            do
            {
                treeStructureTopics.GetTreeTopic();
                Console.WriteLine("*Choose a new topic/sub-topic/ sub-subTopic of this test and write it below this text*\n");
                string topicName = Console.ReadLine();

                var existingTopic = treeStructureTopics.GetTopicName(topicName);
                if (existingTopic == null)
                {
                    Console.WriteLine("!Please, write the name one of topics given below!\n" +
                    $"----Uncurrect topic '{topicName}'");
                }
                topic = existingTopic;
            } while (topic == null);

            updatedtest.Topic = topic.Name;
            string isTimerExist;
            Console.WriteLine("Do you want to update a timer in your test? y/n");
            do
            {
                Console.WriteLine($"Current time in this test is set to: {updatedtest.Time} ");
                isTimerExist = Console.ReadLine();
                if (isTimerExist.ToLower() == "y")
                {

                    int timerHours;
                    int timerMinutes;
                    int timerSeconds;
                    string userTime;
                    int userParsedTime;
                    bool isConverted;
                    do
                    {
                        Console.WriteLine("Please, enter a hours");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerHours = userParsedTime;
                    do
                    {
                        Console.WriteLine("Please, enter a minutes");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerMinutes = userParsedTime;
                    do
                    {
                        Console.WriteLine("Please, enter a seconds");
                        userTime = Console.ReadLine();
                        isConverted = int.TryParse(userTime, out userParsedTime);

                    } while (isConverted == false);
                    timerSeconds = userParsedTime;
                    updatedtest.Time = new TimeSpan(timerHours, timerMinutes, timerSeconds);
                    break;
                }
                else
                {
                    if (isTimerExist.ToLower() == "n")
                    {
                        updatedtest.Time = default;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Please,enter 'y' or 'n' to continue...");

                    }

                }
            } while (isTimerExist != "y" & isTimerExist != "no");


            bool exitFromQuestionChanges = default;

            do
            {
                string selectedFunction;
                bool isUserStringParsed;
                int chosenFunction;
                do
                {
                    Console.WriteLine(@"You can take the following functions : 
                               1) delete existing questions by ID
                               2) delete all existing questions
                               3) add questions to existing");
                    selectedFunction = Console.ReadLine();
                    isUserStringParsed = int.TryParse(selectedFunction, out chosenFunction);

                    if (string.IsNullOrWhiteSpace(selectedFunction))
                    {
                        Console.WriteLine("!!!Alert!!!\n Empty input, please choose something");
                    }
                    else
                    {
                        if (!isUserStringParsed)
                        {
                            Console.WriteLine($"!!!Alert!!!\n {selectedFunction} is not a number, please, try again..");
                        }
                        else
                        {
                            if ((chosenFunction > 3 || chosenFunction < 1))
                            {
                                Console.WriteLine("Incorrect number, try a different");
                            }
                        }
                    }
                } while (!isUserStringParsed || (chosenFunction > 3 || chosenFunction < 1));

                switch (selectedFunction)
                {
                    case "1":
                        bool isParsed;
                        Question deletedItemQuestion;
                        // Answer deletedItemAnswer;
                        string userContinue;
                        bool isExistingQuestion = true;
                        do
                        {
                            if (updatedtest.Questions.Count == 0)
                            {
                                Console.WriteLine("This test has no questions...");
                                break;
                            }


                            Console.WriteLine("Existing questions in this test :");
                            foreach (var questions in updatedtest.Questions)
                            {
                                Console.WriteLine($"{questions.Id})-{questions.Body}");
                            }

                            do
                            {

                                Console.WriteLine("Enter the id of question you want to delete");
                                isParsed = int.TryParse(Console.ReadLine(), out int questionId);
                                if (isParsed)
                                {
                                    deletedItemQuestion = updatedtest.Questions.Where(x => x.Id == questionId).FirstOrDefault();
                                    if (deletedItemQuestion == null)
                                    {
                                        Console.WriteLine("This id is not correct");
                                        isExistingQuestion = false;
                                    }
                                    else
                                    {
                                        testRepository.DeleteQuestionsById(questionId, updatedtest.Id);
                                        Console.WriteLine("Item succesufully deleted");
                                        isExistingQuestion = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This is not a number, please, enter a number");
                                    isExistingQuestion = false;
                                }

                            } while (isParsed != true || isExistingQuestion != true);

                            Console.WriteLine("Do you want to continue delete existing questions? y/n");
                            do
                            {
                                userContinue = Console.ReadLine();
                                if (userContinue.ToLower() == "n")
                                {
                                    Console.WriteLine("Exit from updating questons...");
                                }
                                else
                                {
                                    if (userContinue.ToLower() == "y")
                                    {
                                        Console.WriteLine("Continue...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Uncorrect enter, please, enter y or n");
                                    }
                                }

                            } while (userContinue != "y" && userContinue != "n");
                            if (updatedtest.Questions.Count == 0)
                            {
                                Console.WriteLine("This test has no questions...");
                                break;
                            }
                        } while (userContinue.ToLower() != "n");
                        break;
                    case "2":
                        testRepository.DeleteAllQuestionsAndAnswers(updatedtest.Id);
                        Console.WriteLine("All questions and asnwers has been removed");
                        break;
                    case "3":
                        bool userAnsw = true;
                        do
                        {
                            Console.WriteLine("Please add a question in your test...");
                            string userQuestion = Console.ReadLine();
                            Console.WriteLine("Please, add a answer to the question below...");
                            string answerToUserQuestion = Console.ReadLine();
                            updatedtest.Questions.Add(new Question
                            {
                                Body = userQuestion,
                                Answer = new Answer { Body = answerToUserQuestion }
                            });

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
                                        Console.WriteLine(" You have added new questions...\n");
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
                        testRepository.UpdateTest(updatedtest);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Do you wanna to continue make changes in questions? y/n");
                string userDesision;
                do
                {
                    userDesision = Console.ReadLine();
                    if (userDesision.ToLower() == "n")
                    {
                        Console.WriteLine("Exit from questions changes");
                        exitFromQuestionChanges = false;
                        break;
                    }
                    else
                    {
                        if (userDesision.ToLower() == "y")
                        {
                            Console.WriteLine("Continue updating questions...");
                            exitFromQuestionChanges = true;
                        }
                        else { Console.WriteLine("Please, enter y or n to continue..."); }
                    }
                } while (userDesision.ToLower() != "n" && userDesision.ToLower() != "y");
            } while (exitFromQuestionChanges != false);

            return updatedtest;
        }
    }
}
