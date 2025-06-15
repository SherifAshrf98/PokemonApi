using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _dbContext;

        public PokemonRepository(AppDbContext DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<Pokemon> GetPokmeonWithReviews(int id)
        {
            return await _dbContext.Pokemons.Include(p => p.Reviews).ThenInclude(r => r.Reviewer).FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
