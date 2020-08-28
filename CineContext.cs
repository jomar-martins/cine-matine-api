using cine_matine_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cine_matine_api
{
    public class CineContext : DbContext
    {
        public CineContext(DbContextOptions<CineContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmeModel>().Property(c => c.Nota).HasColumnType("numeric(5,2)");
            builder.Entity<ComentarioModel>().Property(c => c.Nota).HasColumnType("numeric(5,2)");
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<GeneroModel> Genero { get; set; }
        public DbSet<FilmeModel> Filme { get; set; }
        public DbSet<ComentarioModel> Comentario { get; set; }

    }
}
