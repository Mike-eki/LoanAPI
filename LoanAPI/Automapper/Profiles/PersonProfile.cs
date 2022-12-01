using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Context.Entities;

namespace LoanAPI.Models.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}
