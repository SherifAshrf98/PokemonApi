using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Infrastructure.Data;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Implementation.Repositories
{
    public class PokemonOwnerRepository : Repository<PokemonOwner>, IPokemonOwnerRepository
    {
        public PokemonOwnerRepository(AppDbContext DbContext) : base(DbContext) { }


    }

}
