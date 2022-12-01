using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Context.Entities;

namespace LoanAPI.Models.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Categories, CategoriesDTO>().ReverseMap();
        }
    }
}
