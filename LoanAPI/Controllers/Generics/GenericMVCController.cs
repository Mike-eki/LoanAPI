using AutoMapper;
using LoanAPI.Models.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Controllers.Generics
{
    public abstract class GenericMVCController<Model, Entity> : Controller where Entity : class where Model : Models.IModel.IBaseModel, new()
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        protected GenericMVCController(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Get(int? id)
        {
            var model = new Model();
            if (id == null)
            {
                model.Id = 0;
                return PartialView("Get", model);
            }
            Entity entity = await _repository.GetById(id);
            model = _mapper.Map<Model>(entity);
            return PartialView(model);
        }

        [HttpPost]

        public async Task<IActionResult> Save(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entity entity;
            try
            {
                entity = _mapper.Map<Entity>(model);

                if (model.Id > 0)
                {
                    await _repository.Update(entity);
                }
                else
                {
                    await _repository.Insert(entity);
                }
            }
            // Prevenir duplicación desde la base de datos, añadir UNIQUE KEY en determinada columna
            catch (DbUpdateException e)
            when (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                return BadRequest("Este dato esta duplicado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Json(entity);
        }

        [HttpPost, ActionName("DeleteConfirmed")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteById(id);
            return Ok();
            /*
             var deleted = await _repository.DeleteById(id);
             return Ok(deleted);
             */
        }
    }
}
