using PokemonApi.Application.Dtos.PokemonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDto>> GetAllPokmeonsAsync();

        Task<PokemonDto> GetPokemonByIdAsync(int id);

        Task<PokemonDto> AddPokemonAsync(CreatePokemonDto createPokemonDto);

        Task<bool> UpdatePokemonAsync(int id, UpdatePokemonDto updatePokemonDto);

        Task<bool> DeletePokemonAsync(int id);
    }
}
