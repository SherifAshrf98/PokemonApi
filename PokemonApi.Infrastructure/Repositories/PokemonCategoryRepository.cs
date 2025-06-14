using PokemonApi.Infrastructure.Data;
using PokemonApi.Infrastructure.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Repositories
{
    public class PokemonCategoryRepository : Repository<PokemonCategory>, IPokemonCategoryRepository
    {
        public PokemonCategoryRepository(AppDbContext DbContext) : base(DbContext) { }


    }

}
