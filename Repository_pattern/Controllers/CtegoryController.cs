using Microsoft.AspNetCore.Mvc;
using Repository_pattern.Repositories;
//using Repository_pattern.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repository.Get();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repository.Get(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] ProductCategory category)
        {
            await _repository.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] ProductCategory category)
        {
            if (id != category.Id)
                return BadRequest();

            await _repository.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repository.Get(id);
            if (category == null)
                return NotFound();

            await _repository.Delete(category);
            return NoContent();
        }
    }
}
