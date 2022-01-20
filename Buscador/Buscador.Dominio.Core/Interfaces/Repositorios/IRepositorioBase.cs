namespace Buscador.Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();
        void Dispose();
    }
}
