using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;

namespace QuizPrototype.UI
{
    public class UserPrompts
    {
        readonly ITestRepository _repository;
        readonly TreeStructureTopics TreeStructureTopics = new TreeStructureTopics();
        readonly IUserRepository userRepository = new UserRepository();
        public UserPrompts()
        {

        }
        public UserPrompts(ITestRepository repository)
        {
            _repository = repository;
        }

        public string PromptForTargetRandomTestId()
        {
            string topicName;
            List<Test> existingTests = null;
            do
            {
                Console.WriteLine("Choose what the topic/subtopic/sub-sub topic you want to take\n");
                TreeStructureTopics.GetTreeTopic();
                Console.WriteLine("Choose the name of topic you want to take\n");
                topicName = Console.ReadLine();
                existingTests = _repository.GetTestByTopic(topicName);
                if (existingTests.Count == 0)
                {
                    Console.WriteLine($"!!Tests, connected with topic '{topicName}' doesn't exists!!\n");
                }

            } while (existingTests.Count == 0);
            return topicName;
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
                    Console.WriteLine($"{itemTest.Id}) Test title : {itemTest.Title}\n Test description: {itemTest.Description} \n Test Topic: {itemTest.Topic} \n");
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
                var oldTest = _repository.GetTestById(testId);
                if (oldTest == null) { Console.WriteLine("!!!This id doesn't exist!!!\n"); isExisting = false; }
                else { isExisting = true; }
            } while (isExisting == false);
            return testId;
        }


        public void PromptForShowStatistics()
        {
            Console.WriteLine("Showing statistics...\n");
            var allUserTests = userRepository.GetAllUserTests();
            Console.WriteLine($"You passed: {allUserTests.Count}  tests");
            Console.WriteLine("There are entire topics in this application");
            TreeStructureTopics.GetTreeTopic();
            bool isExistingTests = false;
            List<UserTest> passedTestByTopic = null;
            string chosenTopic;
            do
            {
                Console.WriteLine("You can write the one of this topics below to show statistics\n");
                chosenTopic = Console.ReadLine();
                var testsWithTopic = userRepository.GetUserTestByTestTopic(chosenTopic);
                if (testsWithTopic.Count == 0)
                {
                    Console.WriteLine($"You wasn't passing any tests connected with topic '{chosenTopic}' ");
                    isExistingTests = false;
                    TreeStructureTopics.GetTreeTopic();
                }
                else
                {
                    passedTestByTopic = testsWithTopic;
                    isExistingTests = true;
                }
            } while (isExistingTests != true);
            Console.WriteLine($"You have passed {passedTestByTopic.Count} tests connected with {chosenTopic} ");
            Console.WriteLine("These tests are: ");
            var tests = userRepository.GetTestsByUserTestId(chosenTopic);




            foreach (var test in tests)
            {
                Console.WriteLine($"Id: {test.Id} \nTitle: {test.Title}\nDescription: {test.Description}\n" +
                                   $"Topic of test: {test.Topic}\nQuestions count:{test.Questions.Count}\n" +
                                   $"Number of right questions:{test.RightQuestionsCount}\nNumber of wrong questions:{test.WrongQiestionsCount}\n ");

            }








        }
    }
}
