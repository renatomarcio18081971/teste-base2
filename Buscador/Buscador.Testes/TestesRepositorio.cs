using Buscador.Dominio;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using FluentAssertions;
using Moq;
using NSubstitute;
using Xunit;

namespace Buscador.Testes
{
    public class TestesRepositorio
    {
        [Theory(DisplayName = "Busca cep")]
        [InlineData("30130-001")]
        public void TestaBuscaPorCEP(string cep)
        {
            var repositorioBuscaCEP = Substitute.For<IRepositorio<Localizacao>>();
            var retorno = repositorioBuscaCEP.ObterPorCep(cep).Returns(new Localizacao());
            retorno.Should().NotBeNull();
        }

        [Fact]
        public void TestaAdicionarLocalizacao()
        {
            var repositorioLocalizacao = new Mock<IRepositorioLocalizacao>();
            var localizacao = new Localizacao();
            repositorioLocalizacao.Object.Adicionar(localizacao);
            repositorioLocalizacao.Verify(a => a.Adicionar(localizacao), Times.Once);
        }

        [Fact]
        public void TestaObterTodosCEPsGravados()
        {
            var repositorioLocalizacao = new Mock<IRepositorioLocalizacao>();
            var localizacao = new Localizacao();
            repositorioLocalizacao.Object.ObterTodos();
            repositorioLocalizacao.Verify(a => a.ObterTodos(), Times.Once);
        }
    }
}