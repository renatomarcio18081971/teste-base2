using App.CEP.Models;
using App.CEP.Sevicos.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App.CEP.Sevicos.Servicos
{
    public class ConsultaCEP : IConsultaCEP
    {
        public async Task<Localizacao> Obter(string cep)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44325/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync($"Buscador/cep?cep={cep}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro ao buscar cep");
                var retorno = JsonConvert.DeserializeObject<Localizacao>(await response.Content.ReadAsStringAsync());
                return retorno ?? new Localizacao();
            }
        }
    }
}
