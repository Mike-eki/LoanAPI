using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Context.Entities;

namespace LoanAPI.Models.Profiles
{
    public class ThingProfile : Profile
    {
        public ThingProfile()
        {
            CreateMap<Thing, ThingDTO>();
            CreateMap<ThingDTO, Thing>();
        }
    }
}
