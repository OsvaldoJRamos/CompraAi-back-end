using AutoMapper;
using CompraAi.Api.ViewModel;
using CompraAi.Dominio;

namespace CompraAi.Api.Mapeamentos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, CriarUsuarioViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Item, CriarItemViewModel>().ReverseMap();
            CreateMap<Item, EditarItemViewModel>().ReverseMap();
            CreateMap<Status, StatusViewModel>().ReverseMap();
        }
    }
}
