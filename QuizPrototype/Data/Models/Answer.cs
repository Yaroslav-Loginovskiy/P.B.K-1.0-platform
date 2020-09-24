namespace QuizPrototype.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int questionId { get; set; }
    }

}
