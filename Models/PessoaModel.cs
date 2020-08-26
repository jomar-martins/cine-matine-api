namespace cine_matine_api.Models
{
    public class PessoaModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public UsersModel User { get; set; }

    }
}
