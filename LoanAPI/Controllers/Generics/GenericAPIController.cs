using AutoMapper;
using LoanAPI.Context.IEntity;
using LoanAPI.ExtensionMethods;
using LoanAPI.IDTO;
using LoanAPI.Models.DTO;
using LoanAPI.Models.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers.Generics
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericAPIController<DTO, Entity> : ControllerBase where Entity : class, IBaseEntity where DTO : class, IBaseDTO
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Entity> _repository;

        public GenericAPIController(IRepository<Entity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEntity = await _repository.GetAll();

                var listDTO = _mapper.Map<IEnumerable<DTO>>(listEntity);

                return Ok(listDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<DTO>(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                await _repository.DeleteById(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //Verificar de que no añada el dato si ya existe
        public async Task<IActionResult> Create(DTO dto)
        {
            try
            {
                var entity = _mapper.Map<Entity>(dto);

                entity.CreationTime = DateTime.Now;

                entity = await _repository.Insert(entity);

                var newDto = _mapper.Map<DTO>(entity);

                return CreatedAtAction("Get", new { id = newDto.Id }, newDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        // Verificar de no modificar el dato si es que ya existe
        public async Task<IActionResult> Save(int id, DTO dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest();
                }

                var entityItem = await _repository.GetById(id);

                if (entityItem == null)
                {
                    return NotFound();
                }

                var entity = _mapper.Map(dto, entityItem);

                await _repository.Update(entity);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
