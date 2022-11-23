using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Models.Entities;

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
