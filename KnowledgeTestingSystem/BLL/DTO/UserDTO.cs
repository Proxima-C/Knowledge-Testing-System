using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<int> UserTestStatisticsIds { get; set; }
    }
}
