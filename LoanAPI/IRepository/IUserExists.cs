using LoanAPI.Context.Entities;
using LoanAPI.Models;

namespace LoanAPI.IRepository
{
    public interface IUserExists
    { 
        Task<User> UserExists(UserModel userModel);
    }
}
