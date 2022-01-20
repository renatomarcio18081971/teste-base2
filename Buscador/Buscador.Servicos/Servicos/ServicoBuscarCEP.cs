using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using Buscador.Dominio.Core.Interfaces.Servicos;

namespace Buscador.Servicos.Servicos
{
    public class ServicoBuscarCEP : IServicoBuscarCEP
    {
        public readonly IRepositorioBuscaCEP _repositorioBuscaCEP;

        public ServicoBuscarCEP(IRepositorioBuscaCEP repositorioBuscaCEP)
        {
            _repositorioBuscaCEP = repositorioBuscaCEP;
        }

        public Localizacao ObterPorCep(string cep) => _repositorioBuscaCEP.ObterPorCep(cep);
    }
}
