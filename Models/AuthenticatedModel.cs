namespace cine_matine_api.Models
{
    public class AuthenticatedModel
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
