namespace Buscador.Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity ObterPorCep(string cep);
    }
}
