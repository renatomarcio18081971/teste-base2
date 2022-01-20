using Buscador.DTO.DTO;

namespace Buscador.Aplicacao.Interfaces
{
    public interface IAplicacaoBuscarCEP
    {
        LocalizacaoDTO ObterPorCep(string cep);
    }
}
