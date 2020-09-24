using QuizPrototype.Data.Models;
using QuizPrototype.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public int PromptForTargetRandomTestId()
        {
            bool isExisting = false;

            Test test = null;

          
                List<Test> allTests = _repository.GetAllTests();
                Console.WriteLine("Please, choose the topic of test u want to take\n");
                var allTopics = _repository.GetAllTopics();
                var topics = allTopics.Where(c => c.TopicId == null).ToList();
                int i = 0;
                foreach (var topicItem in topics)
                {

                    Console.WriteLine($"{topicItem.Id}) {topicItem.Body}\n");
                }

                // CHECK
                int selectedTopicId = int.Parse(Console.ReadLine());
                var topic = topics.Where(c => c.Id == selectedTopicId).FirstOrDefault();

                var selectTopics = allTopics.Where(c => c.Body == topic.Body).ToList();

                List<Topic> AllSubTopics = new List<Topic>();
                foreach (var selectedTopicItems in selectTopics)
                {

                    foreach (var TopicItem in allTopics)
                    {
                        if (TopicItem.TopicId == selectedTopicItems.Id)
                        {
                            AllSubTopics.Add(TopicItem);
                        }
                    }
                }

                Console.WriteLine("All Existing sub-Topics :\n");
                foreach (var item in AllSubTopics)
                {
                    Console.WriteLine($"{item.Id}) {item.Body}");
                }

                Console.WriteLine("Please, choose the Sub-topic of test u want to take\n");

                int selectedSubTopicId = int.Parse(Console.ReadLine());

                var subTopic = AllSubTopics.Where(x => x.Id == selectedSubTopicId).FirstOrDefault();
                var selectedSubTopics = AllSubTopics.Where(x => x.Body == subTopic.Body).ToList();

                List<Topic> sub_subTopics = new List<Topic>();
                foreach (var selectedItemTopic in selectedSubTopics)
                {
                    foreach (var topicItem in allTopics)
                    {
                        if (selectedItemTopic.Id == topicItem.TopicId)
                        {
                            sub_subTopics.Add(topicItem);
                        }
                    }
                }
                Console.WriteLine("All existing sub-subTopics in application\n");
                foreach (var item in sub_subTopics)
                {
                    Console.WriteLine($"{item.Id}) {item.Body}");
                }

                Console.WriteLine("Please, choose the Sub-Subtopic of test u want to take\n" +
                    "Apllication give you a random test conntected with topic and sub-topic you chose");


                int selectedSubSubTopicId = int.Parse(Console.ReadLine());
                var Sub_SubTopic = allTopics.Where(c => c.Id == selectedSubSubTopicId).FirstOrDefault();
              int testId  = _repository.GetRandomTestByTopic(Sub_SubTopic.Body);

            return testId;

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
                            Console.WriteLine($"{itemTest.Id}) Test title : {itemTest.Title}\n Test description: {itemTest.Description} \n Test sub-theme: {itemTest.Topic.Body} \n");
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
