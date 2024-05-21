using AutoMapper;
using Client.Persistence.Application.Client.DTO;
using Client.Persistence.Application.PublicArea.DTO;

namespace Client.Persistence.Application.AutoMapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Domain.Client.Model.Client, ClientDTO>().ReverseMap();
            CreateMap<Domain.PublicArea.Model.PublicArea, PublicAreaDTO>().ReverseMap();
        }
    }
}
