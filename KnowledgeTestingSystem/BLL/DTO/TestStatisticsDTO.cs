using System;

namespace BLL.DTO
{
    public class TestStatisticsDTO
    {
        public int Id { get; set; }
        public double UserScore { get; set; }
        public TimeSpan PassingTime { get; set; }
        public bool IsPassed { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }
    }
}
