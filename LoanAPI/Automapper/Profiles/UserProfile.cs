using AutoMapper;
using LoanAPI.Context.Entities;
using LoanAPI.Models;

namespace LoanAPI.Automapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
