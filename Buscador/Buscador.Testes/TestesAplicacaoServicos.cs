using Buscador.Aplicacao.Interfaces;
using Buscador.Testes.Helpers;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Buscador.DTO.DTO;
using FluentAssertions;
using System;

namespace Buscador.Testes
{
    public class TestesAplicacaoServicos : IClassFixture<IntegracaoTesteFixture>
    {
        private IAplicacaoServicoLocalizacao _aplicacaoServicoLocalizacao;
        private IAplicacaoBuscarCEP _aplicacaoBuscarCEP;

        public TestesAplicacaoServicos(IntegracaoTesteFixture fixture)
        {
            _aplicacaoServicoLocalizacao = fixture.provedor.GetRequiredService<IAplicacaoServicoLocalizacao>();
            _aplicacaoBuscarCEP = fixture.provedor.GetRequiredService<IAplicacaoBuscarCEP>();
        }

        [Fact]
        public void TestaAdicionarLocalizacao()
        {
            Random randNum = new Random();
            var cep = randNum.Next();
            Action act = () => _aplicacaoServicoLocalizacao.Adicionar(new LocalizacaoDTO
            {
                Logradouro = $"teste {cep}",
                Bairro = $"teste {cep}",
                Localidade = $"teste {cep}",
                UF = $"teste {cep}",
                Cep = cep.ToString(),
                Complemento = $"teste {cep}",
                Ibge = $"teste {cep}",
                Gia = $"teste {cep}",
                DDD = "000",
                Siafi = $"teste {cep}"
            });
            act.Should().NotThrow();
        }

        [Fact]
        public void TestaObterTodosCEPsGravados()
        {
            var retorno = _aplicacaoServicoLocalizacao.ObterTodos();
            retorno.Should().HaveCountGreaterThan(0);
        }

        [Theory(DisplayName = "Busca cep")]
        [InlineData("30130001")]
        public void TestaBuscarCEP(string cep)
        {
            var retorno = _aplicacaoBuscarCEP.ObterPorCep(cep);
            retorno.Should().Match<LocalizacaoDTO>(x => x.Logradouro == "Avenida Afonso Pena");
        }
    }
}
