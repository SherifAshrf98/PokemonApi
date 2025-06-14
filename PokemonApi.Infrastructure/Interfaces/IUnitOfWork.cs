using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Interfaces
{

    public interface IUnitOfWork
    {
        public IRepository<Pokemon> PokemonRepository { get; }
        public IRepository<Country> CountryRepository { get; }
        public Task<int> SaveAsync();
    }
}
