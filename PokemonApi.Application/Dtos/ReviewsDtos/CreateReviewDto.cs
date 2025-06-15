using System.ComponentModel.DataAnnotations;

namespace PokemonApi.Application.Dtos.ReviewsDtos
{
    public class CreateReviewDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public int ReviewerId { get; set; }
    }
}