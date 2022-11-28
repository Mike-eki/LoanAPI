using AutoMapper;
using LoanAPI.Controllers.Generics;
using LoanAPI.Models.DTO;
using LoanAPI.Models.Entities;
using LoanAPI.Models.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    
    public class PersonsController : GenericAPIController<PersonDTO, Person>
    {
        public PersonsController(IRepository<Person> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}

