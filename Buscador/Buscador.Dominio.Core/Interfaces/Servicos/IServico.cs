namespace Buscador.Dominio.Core.Interfaces.Servicos
{
    public interface IServico<T> where T : class
    {
        T ObterPorCep(string cep);
    }
}
