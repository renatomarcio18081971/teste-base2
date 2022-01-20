using App.CEP.Models;

namespace App.CEP.Sevicos.Interfaces
{
    public interface IConsultaCEP
    {
        Task<Localizacao> Obter(string cep);
    }
}
