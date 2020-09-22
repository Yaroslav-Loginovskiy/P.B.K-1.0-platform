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
            DataBaseContext dbContext = new DataBaseContext();
            return dbContext.Tests.ToList();
        }

        public void AddTest(Test newTest)
        {
            context.Tests.Add(newTest);
            context.SaveChanges();
        }
        public Test GetTestById(int testId)
        {

            return context.Tests.Where(y => y.Id == testId).Include(o => o.Questions).ThenInclude(x => x.Answer).FirstOrDefault();
            //var test = context.Tests.Where(x => x.Id == testId).FirstOrDefault();
            //var quest = context.Question.Where(x => x.TestId == testId).FirstOrDefault();
            //List<Question> questions = new List<Question>();
            //var qquestions = context.Question.Where(x => x.TestId == testId).ToList();
            //questions.AddRange(qquestions);
            //List<Answer> answers = new List<Answer>();

            //var answ = context.Answer.Where(x => x.questionId == quest.Id).FirstOrDefault();
            //// quest

            
            //return context.Tests.Where(x => x.Id == testId)
            //.Include(c => c.Questions)

            //.FirstOrDefault();
        }
            
         
        
        public void UpdateTest(Test updatedTest)
        {

            Test updatedtest = updatedTest;
            using (var dbContext = new DataBaseContext())
            {
               // context.Tests.Attach(updatedtest);
              //   context.Entry(updatedtest).State = EntityState.Modified;
                context.SaveChanges();
            }
            //using (var dbContext = new DataBaseContext())
            //{
            //   dbContext.Tests.Attach(updatedtest);
            //   dbContext.Entry(updatedtest).State = EntityState.Modified;
            //   dbContext.SaveChanges();
            //}
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
                    if (item.questionId == questId )
                    {
                        deletedItemsAnsw.Add(item);
                    }
                }
            }
            context.Answer.RemoveRange(deletedItemsAnsw);
            context.SaveChanges();
            
        }

    }
}
