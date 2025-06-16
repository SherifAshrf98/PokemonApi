using PokemonApi.Application.Dtos.OwnerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
        Task<OwnerDto> GetOwnerAsync(int ownerId);
        Task<OwnerDto> AddOwnerAsync(CreateOwnerDto createOwnerDto);
        Task<bool> UpdateOwnerAsync(int id, UpdateOwnerDto owner);
        Task<bool> DeleteOwnerAsync(int id);

    }
}
