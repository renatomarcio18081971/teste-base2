using Buscador.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data
{
    public class BuscadorContext : DbContext
    {
        public BuscadorContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Localizacao>? Localizacao { get; set; }
    }
}