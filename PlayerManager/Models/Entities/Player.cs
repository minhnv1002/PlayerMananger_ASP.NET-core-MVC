using System.ComponentModel.DataAnnotations;

namespace PlayerManager.Models.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string playerName { get; set; } = String.Empty;

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool Contact { get; set; }
    }
}
