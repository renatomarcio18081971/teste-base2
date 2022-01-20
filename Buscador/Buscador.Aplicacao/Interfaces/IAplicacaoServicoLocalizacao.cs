using Buscador.DTO.DTO;

namespace Buscador.Aplicacao.Interfaces
{
    public interface IAplicacaoServicoLocalizacao
    {
        void Adicionar(LocalizacaoDTO entidade);
        LocalizacaoDTO ObterPorCep(string cep);
        IEnumerable<LocalizacaoDTO> ObterTodos();
        void Dispose();
    }
}
