using System.Collections.Generic;

namespace BLL.DTO
{
    public class TestQuestionDTO
    {
        public string Text { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<int> TestQuestionAnswersIds { get; set; }
    }
}
