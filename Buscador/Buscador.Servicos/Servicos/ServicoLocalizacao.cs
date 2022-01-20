using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using Buscador.Dominio.Core.Interfaces.Servicos;

namespace Buscador.Servicos.Servicos
{
    public class ServicoLocalizacao : ServicoBase<Localizacao>, IServicoLocalizacao
    {
        public readonly IRepositorioLocalizacao _repositorioLocalizacao;

        public ServicoLocalizacao(IRepositorioLocalizacao repositorioLocalizacao) : base(repositorioLocalizacao)
        {
        }
    }
}
