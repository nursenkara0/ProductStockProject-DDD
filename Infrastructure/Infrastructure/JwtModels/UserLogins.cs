using System.ComponentModel.DataAnnotations;

namespace Infrastructure.JwtModels
{
    public class UserLogins
    {
        [Required]
        public string Email
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
    }
}
