using App.CEP.Models;

namespace App.CEP.Sevicos.Interfaces
{
    public interface IGravarCEP
    {
        Task Gravar(Localizacao localizacao);
    }
}
