using PokemonApi.Infrastructure.Data;
using PokemonApi.Infrastructure.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Repositories
{
    public class PokemonRepository : Repository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(AppDbContext DbContext) : base(DbContext) { }






    }

}
