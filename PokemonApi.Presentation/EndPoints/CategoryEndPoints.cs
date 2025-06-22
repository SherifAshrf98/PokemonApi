using Carter;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.CategoryDtos;
using PokemonApi.Application.Interfaces.Services;

namespace PokemonApi.Presentation.EndPoints
{
	public class CategoryEndPoints : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			var group = app.MapGroup("api/Category");

			group.MapGet("/", GetCategories);

			group.MapGet("/{categoryid:int}", GetCategory)
				.WithName("GetCategory");

			group.MapPost("/", AddCategory)
				.WithName("AddCategory");

			group.MapPut("/{id:int}", UpdateCategory);

			group.MapDelete("/{id:int}", DeleteCategory)
				.WithName("DeleteCategory");
		}

		public static async Task<IResult> GetCategories(ICategoryService _categoryService)
		{
			var Categories = await _categoryService.GetAllCategoriesAsync();

			if (Categories == null)
				return Results.NotFound("No Categories Found");

			return Results.Ok(Categories);
		}

		public static async Task<IResult> GetCategory(ICategoryService _categoryService, int categoryid)
		{
			var category = await _categoryService.GetCategoryByIdAsync(categoryid);

			if (category == null)
				return Results.NotFound($"Category With Id {categoryid} Not Found");

			return Results.Ok(category);
		}

		public static async Task<IResult> AddCategory(ICategoryService _categoryService, CreateCategoryDto createCategoryDto)
		{

			var AddedCategory = await _categoryService.AddCategoryAsync(createCategoryDto);

			return Results.CreatedAtRoute(nameof(GetCategory), new { categoryid = AddedCategory.Id }, AddedCategory);
		}

		public static async Task<IResult> UpdateCategory(ICategoryService _categoryService, int id, UpdateCategoryDto updateCategoryDto)
		{


			var result = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);

			if (!result)
				return Results.NotFound(result);

			return Results.NoContent();
		}

		public static async Task<IResult> DeleteCategory(ICategoryService _categoryService, int id)
		{
			var result = await _categoryService.DeleteCategoryAsync(id);

			if (!result)
				return Results.NotFound("Category Not found");

			return Results.NoContent();
		}
	}
}
