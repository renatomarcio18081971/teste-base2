using App.CEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App.CEP.Controllers
{
    public class LocalizacaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await Buscar());
        }

        private async Task<IEnumerable<Localizacao>> Buscar()
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync("https://localhost:44325/api/Buscador");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro ao buscar cep");
                var retorno = JsonConvert.DeserializeObject<IEnumerable<Localizacao>>(await response.Content.ReadAsStringAsync());
                return retorno ?? new List<Localizacao>();
            }
        }
    }
}
