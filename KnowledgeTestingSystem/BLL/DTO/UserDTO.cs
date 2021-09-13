using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<int> UserTestStatisticsIds { get; set; }
    }
}
