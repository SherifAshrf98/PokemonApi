using System.ComponentModel.DataAnnotations;

namespace PokemonApi.Application.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}