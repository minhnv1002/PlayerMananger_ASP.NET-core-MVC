namespace PlayerManager.Models.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string playerName { get; set; } = String.Empty;

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Contact { get; set; }
    }
}
