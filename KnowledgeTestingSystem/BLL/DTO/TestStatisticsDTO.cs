using System;

namespace BLL.DTO
{
    public class TestStatisticsDTO
    {
        public int Id { get; set; }
        public double UserScore { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPassed { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
    }
}
