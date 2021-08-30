﻿namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual UserProfile UserProfile {  get; set; }
    }
}
