using Buscador.Data;
using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Repositorios;

namespace Buscador.Repositorio.Repositorio
{
    public class RepositorioLocalizacao : RepositorioBase<Localizacao>, IRepositorioLocalizacao
    {
        private readonly BuscadorContext _context;

        public RepositorioLocalizacao(BuscadorContext context) : base(context)
        {
            _context = context;
        }
    }
}
