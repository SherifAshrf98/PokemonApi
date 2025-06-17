using System.ComponentModel.DataAnnotations;

namespace PokemonApi.Application.Dtos.AuthDtos
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
