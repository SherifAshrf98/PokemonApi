using PokemonApi.Infrastructure.Interfaces;
using PokemonApi.Infrastructure.Repositories;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IRepository<Country> CountryRepository { get; private set; }

        public IRepository<Owner> OwnerRepository { get; private set; }

        public IRepository<Reviewer> ReviewerRepository { get; private set; }

        public IPokemonRepository PokemonRepository { get; private set; }

        public IReviewRepository ReviewRepository { get; private set; }

        public IPokemonOwnerRepository PokemonOwners { get; private set; }

        public IPokemonCategoryRepository PokemonCategories { get; private set; }


        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            PokemonRepository = new PokemonRepository(dbContext);

            ReviewRepository = new ReviewRepository(dbContext);

            PokemonOwners = new PokemonOwnerRepository(dbContext);

            PokemonCategories = new PokemonCategoryRepository(dbContext);

            CountryRepository = new Repository<Country>(dbContext);

            OwnerRepository = new Repository<Owner>(dbContext);

            ReviewerRepository = new Repository<Reviewer>(dbContext);
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
