using AutoMapper;
using CompraAi.Api.Aplicacao.ViewModel;
using CompraAi.Dominio;

namespace CompraAi.Api.Aplicacao.Mapeamentos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
