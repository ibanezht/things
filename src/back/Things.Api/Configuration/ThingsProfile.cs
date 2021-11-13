using AutoMapper;
using Things.Api.Models;
using Things.Common.Dtos;

namespace Things.Api.Configuration
{
    public class ThingsProfile : Profile
    {
        public ThingsProfile()
        {
            CreateMap<Thing, ThingDto>();
        }
    }
}