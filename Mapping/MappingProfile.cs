using AutoMapper;
using Stamps.Controllers.Resources;
using Stamps.Models;

namespace Stamps.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Continent, ContinentResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Category, CategoryResource>();
        }
    }
}