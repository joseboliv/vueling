namespace Domain.GNB.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionEntity : BaseEntity
    {
        [Required]
        public virtual string Sku { get; set; }
        [Required]
        public virtual double Amount { get; set; }
        [Required]
        public virtual string Currency { get; set; }
    }
}
