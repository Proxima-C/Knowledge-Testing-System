namespace BLL.DTO
{
    public class TestAnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int TestQuestionId { get; set; }
    }
}
