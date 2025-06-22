using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Dtos.PokemonDtos
{
    public class PokemonWithCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
