using PokemonApi.Infrastructure.Data;
using PokemonApi.Infrastructure.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Repositories
{
    public class PokemonOwnerRepository : Repository<PokemonOwner>, IPokemonOwnerRepository
    {
        public PokemonOwnerRepository(AppDbContext DbContext) : base(DbContext) { }


    }

}
