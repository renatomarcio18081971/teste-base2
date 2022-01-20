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


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<BuscadorContext>(o => o.UseSqlServer(@"Data Source=DESK01\SQLEXPRESS;Initial Catalog=Buscador;Integrated Security=True"));
builder.Services.AddDbContext<BuscadorContext>(o => o.UseInMemoryDatabase("Buscador"));

var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<LocalizacaoPerfil>(); });
IMapper mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IAplicacaoServicoLocalizacao, AplicacaoServicoLocalizacao>();
builder.Services.AddTransient<IAplicacaoBuscarCEP, AplicacaoBuscarCEP>();
builder.Services.AddTransient<IServicoLocalizacao, ServicoLocalizacao>();
builder.Services.AddTransient<IServicoBuscarCEP, ServicoBuscarCEP>();

builder.Services.AddTransient<IRepositorioLocalizacao, RepositorioLocalizacao>();
builder.Services.AddTransient<IRepositorioBuscaCEP, RepositorioBuscaCEP>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
