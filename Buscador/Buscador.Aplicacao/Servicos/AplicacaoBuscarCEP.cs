using AutoMapper;
using Buscador.Aplicacao.Interfaces;
using Buscador.Dominio.Core.Interfaces.Servicos;
using Buscador.DTO.DTO;

namespace Buscador.Aplicacao.Servicos
{
    public class AplicacaoBuscarCEP : IAplicacaoBuscarCEP
    {
        private readonly IServicoBuscarCEP _servicoBuscarCEP;
        private readonly IMapper _mapper;

        public AplicacaoBuscarCEP(IServicoBuscarCEP servicoBuscarCEP, IMapper mapper)
        {
            _servicoBuscarCEP = servicoBuscarCEP;
            _mapper = mapper;
        }

        public LocalizacaoDTO ObterPorCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) throw new ArgumentNullException("CEP é informação obrigatória !");
            return _mapper.Map<LocalizacaoDTO>(_servicoBuscarCEP.ObterPorCep(cep));
        }
    }
}
