using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TestStatistics> UserTestStatistics { get; set; }
    }
}
