using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Infrastructure.Data;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Implementation.Repositories
{
    public class PokemonCategoryRepository : Repository<PokemonCategory>, IPokemonCategoryRepository
    {
        public PokemonCategoryRepository(AppDbContext DbContext) : base(DbContext) { }


    }

}
