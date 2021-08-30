using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId {  get; set; }

        public virtual User User {  get; set; }
        public virtual ICollection<Test> PassedTests { get; set; }
    }
}
