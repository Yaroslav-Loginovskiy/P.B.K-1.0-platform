using System;
using System.Collections.Generic;
using System.Text;

namespace QuizPrototype.Data.Models.Data
{
    public class Tests
    {
        // some objects of TEST for example.
        public List<Test> allTests = new List<Test>()
         {
            new Test()
            {
                id = 0,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                timer = 100000,
                questions = new List<Question>()
                {
                    new Question() {question = "first question" },
                    new Question() {question  = "second question"},
                    new Question() {question = "third question"}
                },
                answers = new List<Answer>()
                {
                    new Answer() { answer = "1" },
                    new Answer() { answer = "2" },
                    new Answer() { answer = "3" }
                },
                
             },


            new Test(){id = 1,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "first question" } },
                answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },

            new Test(){id = 2,
                title = "buildings",
                subTheme = "stone",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "first question" } },
                answers = new List<Answer>(){ new Answer() { answer = "1" } } },

            new Test(){id = 3,
                title = "animals",
                subTheme = "reptiles",
                description = "reptiles animals",
                questions = new List<Question>(){ new Question() {question = "1" } },
                answers = new List<Answer>(){ new Answer() { answer = "1" } } },


          };


    }
}
