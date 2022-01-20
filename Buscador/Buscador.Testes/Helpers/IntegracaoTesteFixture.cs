using AutoMapper;
using Buscador.Aplicacao.Interfaces;
using Buscador.Aplicacao.Servicos;
using Buscador.Data;
using Buscador.Dominio.Core.Interfaces.Repositorios;
using Buscador.Dominio.Core.Interfaces.Servicos;
using Buscador.Mapper.Perfis;
using Buscador.Repositorio.Repositorio;
using Buscador.Servicos.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Buscador.Testes.Helpers
{
    public class IntegracaoTesteFixture
    {
        public IntegracaoTesteFixture()
        {
            var colecaoDeServicos = new ServiceCollection();
            colecaoDeServicos.AddTransient<IServicoLocalizacao, ServicoLocalizacao>();
            colecaoDeServicos.AddTransient<IServicoBuscarCEP, ServicoBuscarCEP>(); 
            colecaoDeServicos.AddTransient<IRepositorioLocalizacao, RepositorioLocalizacao>();
            colecaoDeServicos.AddTransient<IRepositorioBuscaCEP, RepositorioBuscaCEP>();
            colecaoDeServicos.AddTransient<IAplicacaoServicoLocalizacao, AplicacaoServicoLocalizacao>();
            colecaoDeServicos.AddTransient<IAplicacaoBuscarCEP, AplicacaoBuscarCEP>();
            //colecaoDeServicos.AddDbContext<BuscadorContext>(o => o.UseSqlServer(@"Data Source=DESK01\SQLEXPRESS;Initial Catalog=Buscador;Integrated Security=True"));
            colecaoDeServicos.AddDbContext<BuscadorContext>(o => o.UseInMemoryDatabase("Buscador"));
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<LocalizacaoPerfil>(); });
            IMapper mapper = configuration.CreateMapper();
            colecaoDeServicos.AddSingleton(mapper);
            provedor = colecaoDeServicos.BuildServiceProvider();
        }

        public ServiceProvider provedor { get; private set; }
    }
}
