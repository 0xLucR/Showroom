
using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Contracts.Services.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Domain.Entities.Register.Filters;

namespace Showroom.API.Controllers.Register
{
    [Route("api/register-category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] CategoryFilterEntity filter)
        {
            var categories = _service.GetAll(filter);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _service.GetById(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post(CategoryEntity model)
        {
            var category = model;
            _service.Add(model);

            // Retorna código 201 com as informações para poder consultar o objeto salvo
            return CreatedAtAction("GetById", new { id = category.Id }, category);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, CategoryEntity model)
        {
            var category = _service.GetById(id);

            if (category is null)
                return NotFound();

            category.Update(model.Name, model.Description);
            _service.Update(category);

            return NoContent();
        }

    }
}