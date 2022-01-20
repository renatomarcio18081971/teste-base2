using Buscador.Data;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using Microsoft.Data.SqlClient;

namespace Buscador.Repositorio.Repositorio
{
    public abstract class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly BuscadorContext _context;

        public RepositorioBase(BuscadorContext context)
        {
            _context = context;
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Adicionar(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if ((ex.InnerException != null) && ((SqlException)ex.InnerException).Number == 2627)
                    throw new Exception("CEP já cadastrado !");
                else throw new Exception($"Não foi possível incluir o CEP ! {ex.Message}");
            }
        }

        public virtual TEntity ObterPorCep(string cep)
        {
            return _context.Set<TEntity>().Find(cep);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
