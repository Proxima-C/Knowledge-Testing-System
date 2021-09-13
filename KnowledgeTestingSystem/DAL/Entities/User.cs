namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
