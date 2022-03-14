
using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Contracts.Services.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Domain.Entities.Register.Filters;

namespace Showroom.API.Controllers.Register
{
    [Route("api/register-product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ProductFilterEntity filter)
        {
            var categories = _service.GetAll(filter);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(ProductEntity model)
        {
            var product = model;
            _service.Add(model);

            // Retorna código 201 com as informações para poder consultar o objeto salvo
            return CreatedAtAction("GetById", new { id = product.Id }, product);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, ProductEntity model)
        {
            var product = _service.GetById(id);

            if (product is null)
                return NotFound();

            product.Update(model.Name, model.Description, model.Price);
            _service.Update(product);

            return NoContent();
        }

    }
}