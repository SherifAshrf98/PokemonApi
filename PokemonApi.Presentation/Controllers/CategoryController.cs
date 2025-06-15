using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.CategoryDtos;
using PokemonApi.Application.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var Categories = await _categoryService.GetAllCategoriesAsync();

            if (Categories == null)
                return NotFound("No Categories Found");

            return Ok(Categories);
        }


        [HttpGet("{categoryid}")]
        public async Task<IActionResult> GetCategory(int categoryid)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryid);

            if (category == null)
                return NotFound($"Category With Id {categoryid} Not Found");

            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AddedCategory = await _categoryService.AddCategoryAsync(createCategoryDto);

            return CreatedAtAction(nameof(GetCategory), new { categoryid = AddedCategory.Id }, AddedCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);

            if (!result)
                return NotFound(result);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _categoryService.DeleteCategoryAsync(id);

            if (!result)
                return NotFound("Category Not found");

            return NoContent();
        }

    }
}
