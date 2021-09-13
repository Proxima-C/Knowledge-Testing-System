using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TestStatistics> UserTestStatistics { get; set; }
    }
}
