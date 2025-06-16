using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Infrastructure.Data;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Implementation.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext DbContext) : base(DbContext) { }




    }

}
