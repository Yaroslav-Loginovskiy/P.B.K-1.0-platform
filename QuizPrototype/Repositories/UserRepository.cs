using Microsoft.EntityFrameworkCore;
using QuizPrototype.Data;
using QuizPrototype.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizPrototype.Repositories
{
    public class UserRepository : IUserRepository
    {
        DataBaseContext dbContext = new DataBaseContext();
        public void AddNewTestToUser(User _user)
        {
            User user = _user;
            using (var dataBaseContext = new DataBaseContext())
            {

            }
            
        }

        public void AddNewUser(User user)
        {

        }

        public List<UserTest> GetAllUserTests()
        {

            return dbContext.UserTest.ToList();
        }

        public List<Test> GetTestsByUserTestId(string testTopic)
        {
            var testsWithCurrrentTopic = dbContext.Tests.Where(c => c.Topic == testTopic).Include(a => a.Questions).ToList();
            var userTestsWithSpecId = dbContext.UserTest.ToList();
            var tests = new List<Test>();
            foreach (var item1 in testsWithCurrrentTopic)
            {
                foreach (var item2 in userTestsWithSpecId)
                {
                    if (item1.Id == item2.TestId)
                    {
                        tests.Add(item1);
                    }
                }
            }
            return tests;
        }

        public User GetUserById(int id)
        {
            return dbContext.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<UserTest> GetUserTestByTestTopic(string testTopic)
        {
           
            var testsWithCurrrentTopic = dbContext.Tests.Where(c => c.Topic == testTopic).ToList();

            var userTestsWithSpecId = dbContext.UserTest.ToList();

            var userTests = new List<UserTest>();
            foreach (var item1 in testsWithCurrrentTopic)
            {
                foreach (var item2 in userTestsWithSpecId)
                {
                    if (item1.Id == item2.TestId)
                    {
                        userTests.Add(item2);
                    }
                }
            }
            return userTests;
        }

        public void SaveNewUserTest(UserTest userTest)
        {
            dbContext.UserTest.Add(userTest);
            dbContext.SaveChanges();
        }
    }
}
