using System;

namespace DAL.Entities
{
    public class TestStatistics : BaseEntity
    {
        public double UserScore { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPassed { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }

        public virtual Test Test { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
