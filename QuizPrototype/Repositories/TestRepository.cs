using Microsoft.EntityFrameworkCore;
using QuizPrototype.Data;
using QuizPrototype.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizPrototype.Repositories
{
    public class TestRepository : ITestRepository
    {

        DataBaseContext context = new DataBaseContext();
        public TestRepository()
        {
            tests = new List<Test>();
        }
        private List<Test> tests;

        public List<Test> GetAllTests()
        {
            using (var dbContext = new DataBaseContext())
            {

                return dbContext.Tests.Include(c => c.Questions).ThenInclude(g => g.Answer).ToList();
            }
        }

        public void AddTest(Test newTest)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Database.EnsureCreated();
                dbContext.Tests.Add(newTest);
                dbContext.SaveChanges();
            }
        }
        public Test GetTestById(int testId)
        {

            return context.Tests.Where(y => y.Id == testId).Include(o => o.Questions).ThenInclude(x => x.Answer).FirstOrDefault();

        }

        public List<Topic> GetAllTopics()
        {
            return context.Topic.ToList();
        }

        public void UpdateTest(Test updatedTest)
        {

            Test updatedtest = updatedTest;
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Tests.Attach(updatedtest);
                dbContext.Entry(updatedtest).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
           
        }
        public void DeleteQuestionsById(int questionId, int updatedTestId)
        {
            var deletedItemQuest = context.Question.Where(x => x.Id == questionId).Where(c => c.TestId == updatedTestId).FirstOrDefault();
            context.Question.Remove(deletedItemQuest);
            context.SaveChanges();
            DeleteAnswerById(deletedItemQuest.Id);
        }
        public void DeleteAnswerById(int questionId)
        {
            var deletedItemAnswer = context.Answer.Where(x => x.questionId == questionId).ToList();
            context.Answer.RemoveRange(deletedItemAnswer);
            context.SaveChanges();
        }
        public void DeleteAllQuestionsAndAnswers(int updatedTestId)
        {
            var deletedItemsQuest = context.Question.Where(x => x.TestId == updatedTestId).ToList();
            context.Question.RemoveRange(deletedItemsQuest);
            List<int> QuestionId = new List<int>();
            foreach (var question in deletedItemsQuest)
            {
                QuestionId.Add(question.Id);
            }

            List<Answer> deletedItemsAnsw = new List<Answer>();
            foreach (var questId in QuestionId)
            {
                foreach (var item in context.Answer)
                {
                    if (item.questionId == questId)
                    {
                        deletedItemsAnsw.Add(item);
                    }
                }
            }
            context.Answer.RemoveRange(deletedItemsAnsw);
            context.SaveChanges();

        }

        public List<Test> GetTestByTopic(string topic)
        {
            return context.Tests.Where(x => x.Topic == topic).Include(c => c.Questions).ThenInclude(a => a.Answer).ToList();
        }


        public Test GetRandomTestByTopic(string topic)
        {
           List<Test> testsWithSpecTopic = context.Tests.Where(x => x.Topic == topic).Include(c => c.Questions).ThenInclude(a => a.Answer).ToList();
           Random random = new Random();
           int randomId = random.Next(testsWithSpecTopic.Count);
           Test test = testsWithSpecTopic[randomId];
           return test;
        }
        public void AddNewQuestion(Question question)
        {
            context.Question.Add(question);
            context.SaveChanges();
        }
    }
}
