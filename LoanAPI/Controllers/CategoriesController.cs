using AutoMapper;
using LoanAPI.Controllers.Generics;
using LoanAPI.Models.DTO;
using LoanAPI.Context.Entities;
using LoanAPI.Models.IRepository;
using LoanAPI.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    public class CategoriesController : GenericAPIController<CategoriesDTO, Categories>
    {
        public CategoriesController(IRepository<Categories> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}