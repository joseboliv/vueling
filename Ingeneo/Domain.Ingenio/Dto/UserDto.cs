using System.ComponentModel.DataAnnotations;

namespace Domain.Ingenio.Dto
{
    public class UserDto
    {
        public UserDto()
        {

        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
