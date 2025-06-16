using PokemonApi.Application.Dtos.CountryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Application.Interfaces.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto> GetCountryByIdAsync(int id);
        Task<CountryDto> AddCountryAsync(CreateCountryDto createCountryDto);
        Task<bool> UpdateCountryAsync(int id, UpdateCountryDto createCountryDto);
        Task<bool> DeleteCountryAsync(int id);
    }
}
