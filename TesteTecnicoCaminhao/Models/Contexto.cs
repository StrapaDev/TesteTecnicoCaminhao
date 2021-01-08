using Microsoft.EntityFrameworkCore;

namespace TesteTecnicoCaminhao.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Caminhao> Caminhoes { get; set; }
    }
}
