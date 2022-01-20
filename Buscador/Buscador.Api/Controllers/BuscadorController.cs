using Buscador.Aplicacao.Interfaces;
using Buscador.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Buscador.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscadorController : ControllerBase
    {
        private readonly IAplicacaoServicoLocalizacao _aplicacaoServicoLocalizacao;
        private readonly IAplicacaoBuscarCEP _aplicacaoBuscarCEP;
        private const string OPERACAOINVALIDA = "Operação inválida !";

        public BuscadorController(IAplicacaoServicoLocalizacao aplicacaoServicoLocalizacao,
                                  IAplicacaoBuscarCEP aplicacaoBuscarCEP)
        {
            _aplicacaoServicoLocalizacao = aplicacaoServicoLocalizacao;
            _aplicacaoBuscarCEP = aplicacaoBuscarCEP;
        }


        [HttpGet("cep")]
        public LocalizacaoDTO BuscarPorCEP(string cep) 
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException(OPERACAOINVALIDA);
            bool cepValido = validadorDeCep(cep);
            if (!cepValido) throw new Exception("Cep inválido !");
            return _aplicacaoBuscarCEP.ObterPorCep(cep);
        }

        [HttpPost]
        public void Post([FromBody] LocalizacaoDTO acao)
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException(OPERACAOINVALIDA);
            _aplicacaoServicoLocalizacao.Adicionar(acao);
        }

        [HttpGet()]
        public IEnumerable<LocalizacaoDTO> BuscarTodosOsRegistrosCadastrados()
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException(OPERACAOINVALIDA);
            return _aplicacaoServicoLocalizacao.ObterTodos();
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
