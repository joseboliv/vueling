namespace Domain.Ingenio.Entity
{
    public class Author : BaseEntity
    {
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual double Rate { get; set; }
    }
}
