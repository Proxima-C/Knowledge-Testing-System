using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId {  get; set; }

        public User User {  get; set; }
        public ICollection<Test> PassedTests { get; set; }
    }
}
