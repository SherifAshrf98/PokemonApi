using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces.Repositories
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
        Task<Pokemon> GetPokmeonWithReviews(int id);
    }


}
