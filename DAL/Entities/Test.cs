using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Test : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan TestDuration { get; set; }

        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
