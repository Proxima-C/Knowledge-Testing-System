using System.Collections.Generic;

namespace DAL.Entities
{
    public class TestQuestion : BaseEntity
    {
        public string Text { get; set; }
        public int TestId { get; set; }

        public virtual Test Test {  get; set; }
        public virtual ICollection<TestAnswer> TestQuestionAnswers { get; set; }
    }
}
