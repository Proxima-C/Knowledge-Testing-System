using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TestStatistics> UserTestStatistics { get; set; }
    }
}
