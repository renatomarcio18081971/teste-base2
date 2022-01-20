namespace Buscador.Dominio.Core.Interfaces.Servicos
{

    public interface IServicoBase<T> : IServico<T> where T : class
    {
        void Adicionar(T entidade);
        IEnumerable<T> ObterTodos();
    }
}
