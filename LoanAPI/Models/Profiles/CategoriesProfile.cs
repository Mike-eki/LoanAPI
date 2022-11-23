using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Models.Entities;

namespace LoanAPI.Models.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Categories, CategoriesDTO>();
            CreateMap<CategoriesDTO, Categories>();
        }
    }
}
