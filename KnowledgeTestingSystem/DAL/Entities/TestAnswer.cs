namespace DAL.Entities
{
    public class TestAnswer : BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int TestQuestionId { get; set; }

        public virtual TestQuestion TestQuestion { get; set; }
    }
}
