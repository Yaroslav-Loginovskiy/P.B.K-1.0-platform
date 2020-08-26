using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Data.Models.Data
{
    public class Tests
    {

        public List<Test> allTests = new List<Test>()
         {
            new Test(){id = 0,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "WTF?" } },
                answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },


            new Test(){id = 1,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "WTF?" } },
                answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },

            new Test(){id = 2,
                title = "buildings",
                subTheme = "stone",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "WTF?" } },
                answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },

            new Test(){id = 3,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "WTF?" } },
                answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },


          };


    }
}
