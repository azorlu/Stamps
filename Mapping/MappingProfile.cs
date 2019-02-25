using AutoMapper;
using Stamps.Controllers.Resources;
using Stamps.Core.Models;

namespace Stamps.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain -> API Resource
            CreateMap<Photo, PhotoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Continent, ContinentResource>();
            CreateMap<Continent, KeyValuePairResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Country, KeyValuePairResource>();
            CreateMap<Category, KeyValuePairResource>();
            CreateMap<Stamp, SaveStampResource>();
            CreateMap<Stamp, StampResource>()
            .ForMember(sr => sr.Continent, opt => opt.MapFrom(s => s.Country.Continent));

            // API Resource -> Domain
            CreateMap<StampQueryResource, StampQuery>();
            CreateMap<SaveStampResource, Stamp>()
            .ForMember(s => s.Id, opt => opt.Ignore())
            .ForMember(s => s.LastUpdate, opt => opt.Ignore());
            CreateMap<StampResource, Stamp>();
        }
    }
}