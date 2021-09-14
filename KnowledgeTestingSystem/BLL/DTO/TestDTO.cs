using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TestDuration { get; set; }

        public virtual ICollection<int> TestQuestionsIds { get; set; }
    }
}
