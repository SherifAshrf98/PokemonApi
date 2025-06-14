using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Dtos.PokemonDtos
{
    public class CreatePokemonDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
