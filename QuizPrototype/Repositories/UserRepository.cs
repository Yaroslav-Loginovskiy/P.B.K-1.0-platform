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
        public void AddNewTestToUser(UserTest userTest,User _user)
        {
            _user.UserTest = userTest;
            using (var dbContext = new DataBaseContext())
            {
               



                dbContext.User.Add(_user);
                dbContext.SaveChanges();
            }
           
        }

        public void AddNewUser(User user)
        {

        }
        public User GetUserById(int id)
        {
            return dbContext.User.Where(x => x.Id == id).FirstOrDefault();
        }

       
    }
}
