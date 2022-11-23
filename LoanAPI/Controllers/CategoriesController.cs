using AutoMapper;
using LoanAPI.Models.DTO;
using LoanAPI.Models.Entities;
using LoanAPI.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCategories = await _categoriesRepository.GetListCategories();

                var listCategoriesDTO = _mapper.Map<IEnumerable<CategoriesDTO>>(listCategories);

                return Ok(listCategoriesDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoriesRepository.GetCategory(id);

                if(category == null)
                {
                    return NotFound();
                }

                var categoryDTO = _mapper.Map<CategoriesDTO>(category);

                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoriesRepository.GetCategory(id);

                if (category == null)
                {
                    return NotFound();
                }

                await _categoriesRepository.DeleteCategory(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoriesDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Categories>(categoryDTO);

                category.CreationDate = DateTime.Now;

                category = await _categoriesRepository.CreateCategory(category);

                var newCategoryDTO = _mapper.Map<CategoriesDTO>(category);

                return CreatedAtAction("Get", new { id = newCategoryDTO.Id }, newCategoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(int id, CategoriesDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Categories>(categoryDTO);

                if(id != category.Id)
                {
                    return BadRequest();
                }

                var categoryItem = await _categoriesRepository.GetCategory(id);

                if (categoryItem == null)
                {
                    return NotFound();
                }
                
                await _categoriesRepository.UpdateCategory(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
