namespace QuizPrototype.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public Answer Answer { get; set; }
        public int TestId { get; set; }


        enum Type
        {
            Open,
            Closed
        }

    }
}
