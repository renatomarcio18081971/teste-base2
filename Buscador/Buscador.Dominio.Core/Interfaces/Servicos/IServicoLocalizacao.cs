namespace Buscador.Dominio.Core.Interfaces.Servicos
{
    public interface IServicoLocalizacao : IDisposable
    {
        void Adicionar(Localizacao entidade);
        IEnumerable<Localizacao> ObterTodos();
        Localizacao ObterPorCep(string cep);
    }
}
