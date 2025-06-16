using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Infrastructure.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Implementation.Repositories
{
    public class ReviewerRepository : Repository<Reviewer>, IReviewerRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewerRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
