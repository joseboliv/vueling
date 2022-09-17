namespace Domain.GNB.Entity
{
    public class RateEntity : BaseEntity
    {
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual double Rate { get; set; }
    }
}
