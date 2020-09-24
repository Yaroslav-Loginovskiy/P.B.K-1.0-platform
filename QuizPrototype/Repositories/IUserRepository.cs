using QuizPrototype.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Repositories
{
    interface IUserRepository
    {
        void AddNewTestToUser(UserTest userTest, User user);
        void AddNewUser(User user);
        User GetUserById(int id);
    }
}
