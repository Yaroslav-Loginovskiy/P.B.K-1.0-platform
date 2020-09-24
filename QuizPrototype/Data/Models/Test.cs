using System.Collections.Generic;

namespace QuizPrototype.Data.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTheme { get; set; }
        public string SubSubTheme { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
        public int? Timer { get; set; }
        public bool accept { get; set; } = true;
    }
}
