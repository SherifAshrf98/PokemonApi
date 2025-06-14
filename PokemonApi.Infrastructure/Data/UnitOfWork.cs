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
        public IRepository<Pokemon> PokemonRepository { get; private set; }
        public IRepository<Country> CountryRepository { get; private set; }
        public IRepository<Owner> OwnerRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            PokemonRepository = new Repository<Pokemon>(dbContext);

            CountryRepository = new Repository<Country>(dbContext);

            OwnerRepository = new Repository<Owner>(dbContext);
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
