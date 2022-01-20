using AutoMapper;
using Buscador.Dominio;
using Buscador.DTO.DTO;

namespace Buscador.Mapper.Perfis
{
    public class LocalizacaoPerfil : Profile
    {
        public LocalizacaoPerfil()
        {
            CreateMap<Localizacao, LocalizacaoDTO>();
            CreateMap<LocalizacaoDTO, Localizacao>();
        }
    }
}
