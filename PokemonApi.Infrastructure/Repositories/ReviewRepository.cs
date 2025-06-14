using PokemonApi.Infrastructure.Data;
using PokemonApi.Infrastructure.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonApi.Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext DbContext) : base(DbContext) { }




    }

}
