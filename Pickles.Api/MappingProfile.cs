using AutoMapper;
using Pickles.Api.Models;
using Pickles.Data.Models;

namespace Pickles.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PickleType, PickleTypeApiModel>();
            CreateMap<PickleStyle, PickleStyleApiModel>();
        }
    }
}
