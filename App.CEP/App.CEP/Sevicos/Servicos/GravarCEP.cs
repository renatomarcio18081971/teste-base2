using App.CEP.Models;
using App.CEP.Sevicos.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App.CEP.Sevicos.Servicos
{
    public class GravarCEP : IGravarCEP
    {
        public async Task Gravar(Localizacao localizacao)
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var retorno = JsonConvert.SerializeObject(localizacao);
                HttpContent content = new StringContent(retorno);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                HttpResponseMessage response = await cliente.PostAsync("https://localhost:44325/api/Buscador", content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro ao gravar cep");
            }
        }
    }
}
