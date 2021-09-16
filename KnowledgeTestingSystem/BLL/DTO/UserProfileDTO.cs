using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<int> UserTestStatisticsIds { get; set; }
    }
}
