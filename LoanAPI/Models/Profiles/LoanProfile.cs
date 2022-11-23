using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Models.Entities;

namespace LoanAPI.Models.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDTO>();
            CreateMap<LoanDTO, Loan>();
        }
    }
}
