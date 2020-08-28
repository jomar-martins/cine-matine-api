namespace cine_matine_api.Models
{
    public class ComentarioModel
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public decimal Nota { get; set; }
        public UsersModel User { get; set; }
        public FilmeModel Filme { get; set; }
    }
}
