using System.Collections.Generic;

namespace QuizPrototype.Data.Models.Data
{
    public static class Tests
    {
        // some objects of TEST for example.
        public static List<Test> allTests = new List<Test>()
         {
            new Test()
            {
                Id = 0,
                Title = "animals",
                SubTheme = "reptiles",
                Description = "reptiles animals",
                Timer = 1,
                accept = true,
                Questions = new List<Question>()
                {
                    new Question() {question = "first question" },
                    new Question() {question  = "second question"},
                    new Question() {question = "third question"}
                },
                Answers = new List<Answer>()
                {
                    new Answer() { answer = "1" },
                    new Answer() { answer = "2" },
                    new Answer() { answer = "3" }
                },
             },

            new Test(){
                Id = 1,
                Title = "animals",
                SubTheme = "reptiles",
                Description = "reptiles animals",
                Questions = new List<Question>(){ new Question() {question = "first question" } },
                Answers = new List<Answer>(){ new Answer() { answer = "NOWTF" } } },

            new Test(){
                Id = 2,
                Title = "buildings",
                SubTheme = "stone",
                Description = "reptiles animals",
                Questions = new List<Question>(){ new Question() {question = "first question" } },
                Answers = new List<Answer>(){ new Answer() { answer = "1" } } },

            new Test(){
                Id = 3,
                Title = "animals",
                SubTheme = "reptiles",
                Description = "reptiles animals",
                Questions = new List<Question>(){ new Question() {question = "1" } },
                Answers = new List<Answer>(){ new Answer() { answer = "1" } } },
         };
    }
}
