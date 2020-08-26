namespace cine_matine_api.Models
{
    public class UsersModel
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
    }
}
