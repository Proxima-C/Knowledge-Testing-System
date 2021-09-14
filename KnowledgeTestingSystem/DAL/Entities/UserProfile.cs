using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TestStatistics> UserTestStatistics { get; set; }
    }
}
