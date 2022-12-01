using AutoMapper;
using LoanAPI.Context;
using LoanAPI.Context.Entities;
using LoanAPI.Models;
using LoanAPI.Models.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        //private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(AplicationDbContext context, IConfiguration config)
        {
            //_mapper = mapper;
            _context = context;
            _config = config;
        }

        [HttpPost]

        public async Task<IActionResult> Login(UserModel userModel)
        {
            var userLogin = Authenticate(userModel);

            if(userLogin != null)
            {
                var token = Generate(userLogin);
                var response = new JwtResponse();
                response.Token = token;
                return Ok(response);
            }

            return NotFound("User not found");
        }

        private User Authenticate(UserModel userModel)
        {
            var foundUser = _context.Users.FirstOrDefault(
                user => user.Username == userModel.Username && user.Password == userModel.Password);

            if(foundUser != null)
            {
                //var userLogin = _mapper.Map<UserModel>(foundUser);

                return foundUser;
            }

            return null;
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                            _config["Jwt:Issuer"],
                            _config["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(15),
                            signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
