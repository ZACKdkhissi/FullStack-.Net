using System.ComponentModel.DataAnnotations;

namespace UniverMnagment.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username must be between 5 and 100 characters", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
