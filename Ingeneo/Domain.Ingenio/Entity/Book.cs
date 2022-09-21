namespace Domain.Ingenio.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Book : BaseEntity
    {
        [Required]
        public virtual string Sku { get; set; }
        [Required]
        public virtual double Amount { get; set; }
        [Required]
        public virtual string Currency { get; set; }
    }
}
