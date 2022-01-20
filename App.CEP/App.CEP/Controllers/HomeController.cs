using App.CEP.Sevicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace App.CEP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsultaCEP _consultaCEP;
        private readonly IGravarCEP _gravarCEP;

        public HomeController(ILogger<HomeController> logger, IConsultaCEP consultaCEP, IGravarCEP gravarCEP)
        {
            _logger = logger;
            _consultaCEP = consultaCEP;
            _gravarCEP = gravarCEP;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cep)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(cep))
                return BadRequest(ModelState);
            bool cepValido = validadorDeCep(cep);
            if (!cepValido) throw new Exception("Cep inválido !");
            var retorno = await _consultaCEP.Obter(cep);
            await _gravarCEP.Gravar(retorno);
            return View(retorno);
        }
        private bool validadorDeCep(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}\d{3}$");
            if (!Rgx.IsMatch(cep))
                 return false;
            return true;
        }
    }
}