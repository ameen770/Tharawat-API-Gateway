using TharawatGateway.Domain.Entities;
using TharawatGateway.WebAPI.ViewModels;
using AutoMapper;

namespace TharawatGateway.WebAPI.Mapper
{
    public class ModelsMapping : Profile
    {
        public ModelsMapping()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}