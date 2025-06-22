using PokemonApi.Application.Dtos.CategoryDtos;
using PokemonApi.Application.Dtos.PokemonDtos;
using PokemonApi.Application.Dtos.Reviews;
using PokemonApi.Application.Dtos.ReviewsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDto>> GetAllPokmeonsAsync();

        Task<PokemonDto> GetPokemonByIdAsync(int id);

        Task<PokemonDto> AddPokemonAsync(CreatePokemonDto createPokemonDto);

        Task<bool> UpdatePokemonAsync(int id, UpdatePokemonDto updatePokemonDto);

        Task<bool> DeletePokemonAsync(int id);

        Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Pokemonid);

        Task<ReviewDto> AddReviewAsync(int Pokemonid, CreateReviewDto createReviewDto);

        Task<bool> DeleteReviewAsync(int pokemonid, int Reviewid);

        Task<PokemonWithCategoriesDto> GetCategoriesAsync(int pokemonid);

    }
}
