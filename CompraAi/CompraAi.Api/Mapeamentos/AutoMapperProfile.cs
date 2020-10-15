using AutoMapper;
using CompraAi.Api.ViewModel;
using CompraAi.Dominio;

namespace CompraAi.Api.Mapeamentos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
