namespace NBA.ArenaManagement.WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Arena { get; set; }
        public string Error { get; set; }
    }
}