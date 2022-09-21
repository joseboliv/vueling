namespace Domain.Ingenio.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        [Required]
        public virtual string userName { get; set; }
        [Required]
        public virtual string password { get; set; }
    }
}
