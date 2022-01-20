using Buscador.Data;
using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Buscador.Repositorio.Repositorio
{
    public class RepositorioBuscaCEP : IRepositorioBuscaCEP
    {
        public Localizacao ObterPorCep(string cep) => Buscar(cep).Result;

        private async Task<Localizacao> Buscar(string cep)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://viacep.com.br/ws/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync($"{cep}/json/");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro ao buscar cep : {cep}");
                var retorno = JsonConvert.DeserializeObject<Localizacao>(await response.Content.ReadAsStringAsync());
                return retorno ?? new Localizacao();
            }
        }
    }
}
