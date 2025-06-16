using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        public IPokemonRepository PokemonRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IPokemonOwnerRepository PokemonOwners { get; }
        public IPokemonCategoryRepository PokemonCategories { get; }
        public IRepository<Country> CountryRepository { get; }
        public IRepository<Owner> OwnerRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Reviewer> ReviewerRepository { get; }
        public Task<int> SaveAsync();
    }
}
