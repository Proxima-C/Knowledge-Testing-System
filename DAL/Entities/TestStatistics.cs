using System;

namespace DAL.Entities
{
    public class TestStatistics : BaseEntity
    {
        public double UserScore { get; set; }
        public TimeSpan PassingTime { get; set; }
        public bool IsPassed { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }

        public virtual Test Test { get; set; }
        public virtual User User { get; set; }

    }
}
