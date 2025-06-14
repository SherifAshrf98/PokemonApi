using Microsoft.EntityFrameworkCore.Update.Internal;
using PokemonApi.Application.Dtos.PokemonDtos;
using PokemonApi.Application.Interfaces;
using PokemonApi.Infrastructure.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PokemonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PokemonDto>> GetAllPokmeonsAsync()
        {
            var Pokemons = await _unitOfWork.PokemonRepository.GetAllAsync();

            var PokemonsToReturn = Pokemons.Select(p => new PokemonDto
            {
                Id = p.Id,
                Name = p.Name,
                Birthdate = p.BirthDate
            });

            return PokemonsToReturn;
        }

        public async Task<PokemonDto> GetPokemonByIdAsync(int id)
        {
            var pokemon = await _unitOfWork.PokemonRepository.GetByIdAsync(id);

            if (pokemon == null)
                return null;

            var pokemonToReturn = new PokemonDto
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Birthdate = pokemon.BirthDate
            };

            return pokemonToReturn;
        }

        public async Task<PokemonDto> AddPokemonAsync(CreatePokemonDto createPokemonDto)
        {
            var pokemon = await _unitOfWork.PokemonRepository.FindAsync(p => p.Name == createPokemonDto.Name);

            if (pokemon != null)
                throw new InvalidOperationException("Pokemon With The Same Name Already Exists");

            var NewPokemon = new Pokemon
            {
                Name = createPokemonDto.Name,

                BirthDate = createPokemonDto.BirthDate,
            };

            var Pokemon = await _unitOfWork.PokemonRepository.AddAsync(NewPokemon);

            await _unitOfWork.SaveAsync();

            var PokemonDto = new PokemonDto
            {
                Id = Pokemon.Id,

                Name = Pokemon.Name,

                Birthdate = Pokemon.BirthDate,
            };

            return PokemonDto;
        }

        public async Task<bool> UpdatePokemonAsync(int id, UpdatePokemonDto updatePokemonDto)
        {
            var pokemon = await _unitOfWork.PokemonRepository.GetByIdAsync(id);

            if (pokemon is null)
                return false;

            if (updatePokemonDto.Name is not null)
                pokemon.Name = updatePokemonDto.Name;

            if (updatePokemonDto.BirthDate.HasValue)
                pokemon.BirthDate = updatePokemonDto.BirthDate.Value;

            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            var pokemon = await _unitOfWork.PokemonRepository.GetByIdAsync(id);

            if (pokemon is null)
                return false;

            _unitOfWork.PokemonRepository.Remove(pokemon);

            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
