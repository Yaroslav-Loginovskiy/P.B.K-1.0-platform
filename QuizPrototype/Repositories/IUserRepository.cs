using QuizPrototype.Data.Models;
using System.Collections.Generic;

namespace QuizPrototype.Repositories
{
    interface IUserRepository
    {
        void AddNewTestToUser(User user);
        void AddNewUser(User user);
        User GetUserById(int id);
        public void SaveNewUserTest(UserTest userTest);
        List<UserTest> GetAllUserTests();
        List<UserTest> GetUserTestByTestTopic(string testTopic);
        List<Test> GetTestsByUserTestId(string userTopic);
    }
}
