using AutoMapper;
using Buscador.Aplicacao.Interfaces;
using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Servicos;
using Buscador.DTO.DTO;

namespace Buscador.Aplicacao.Servicos
{
    public class AplicacaoServicoLocalizacao : IAplicacaoServicoLocalizacao
    {
        private readonly IServicoLocalizacao _servicoLocalizacao;
        private readonly IMapper _mapper;

        public AplicacaoServicoLocalizacao(IServicoLocalizacao servicoLocalizacao, IMapper mapper)
        {
            _servicoLocalizacao = servicoLocalizacao;
            _mapper = mapper;
        }

        public void Adicionar(LocalizacaoDTO entidade)
        {
            if (entidade == null) throw new ArgumentNullException("Entidade é informação obrigatória !");
            _servicoLocalizacao.Adicionar(_mapper.Map<Localizacao>(entidade));
        }

        public void Dispose() => _servicoLocalizacao.Dispose();

        public LocalizacaoDTO ObterPorCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) throw new ArgumentNullException("CEP é informação obrigatória !");
            return _mapper.Map<LocalizacaoDTO>(_servicoLocalizacao.ObterPorCep(cep));
        }

        public IEnumerable<LocalizacaoDTO> ObterTodos() => 
            _mapper.Map<IEnumerable<LocalizacaoDTO>>(_servicoLocalizacao.ObterTodos());
        
    }
}
