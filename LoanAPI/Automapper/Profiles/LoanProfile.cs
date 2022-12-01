using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Context.Entities;

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
