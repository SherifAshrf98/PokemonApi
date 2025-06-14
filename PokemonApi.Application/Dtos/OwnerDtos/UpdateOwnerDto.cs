using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Dtos.OwnerDtos
{
    public class UpdateOwnerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gym { get; set; }
        public int? CountryID { get; set; }
    }
}
