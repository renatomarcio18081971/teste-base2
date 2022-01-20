namespace Buscador.Dominio.Core.Interfaces.Servicos
{
    public interface IServicoBuscarCEP
    {
        Localizacao ObterPorCep(string cep);
    }
}
