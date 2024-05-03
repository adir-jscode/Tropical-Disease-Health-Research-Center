namespace TDHRC.Models
{
    public class Admin
    {
        public string Id { get; set; } = "A-" + DateTime.Now;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
