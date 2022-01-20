using Buscador.Dominio.Core.Interfaces.Repositorios;
using Buscador.Dominio.Core.Interfaces.Servicos;

namespace Buscador.Servicos.Servicos
{
    public abstract class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repository;

        public ServicoBase(IRepositorioBase<TEntity> Repository)
        {
            _repository = Repository;
        }

        public virtual void Adicionar(TEntity obj) => _repository.Adicionar(obj);
        public virtual TEntity ObterPorCep(string cep) => _repository.ObterPorCep(cep);
        public virtual void Dispose() => _repository.Dispose();
        public IEnumerable<TEntity> ObterTodos() => _repository.ObterTodos();
    }
}
