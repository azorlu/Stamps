using AutoMapper;
using Stamps.Controllers.Resources;
using Stamps.Models;

namespace Stamps.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Continent, ContinentResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Stamp, StampResource>();

            // API Resourec to Domain
            CreateMap<StampResource, Stamp>()
            .ForMember(s => s.Id, opt => opt.Ignore())
            .ForMember(s => s.LastUpdate, opt => opt.Ignore());
        }
    }
}