using PokemonApi.Application.Dtos.CountryDtos;
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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var Countries = await _unitOfWork.CountryRepository.GetAllAsync();

            if (Countries is null)
                return null;

            var CountriesToReturn = Countries.Select(c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name,
            });

            return CountriesToReturn;
        }
        public async Task<CountryDto> GetCountryByIdAsync(int id)
        {
            var Country = await _unitOfWork.CountryRepository.GetByIdAsync(id);

            if (Country is null)
                return null;

            var CountryDto = new CountryDto
            {
                Id = Country.Id,

                Name = Country.Name

            };

            return CountryDto;
        }
        public async Task<CountryDto> AddCountryAsync(CreateCountryDto createCountryDto)
        {
            var exisitingCountry = await _unitOfWork.CountryRepository.FindAsync(c => c.Name == createCountryDto.Name);

            if (exisitingCountry is not null)
                throw new InvalidOperationException("This Country already Exists");

            var NewCountry = new Country
            {
                Name = createCountryDto.Name
            };

            var Country = await _unitOfWork.CountryRepository.AddAsync(NewCountry);
            await _unitOfWork.SaveAsync();

            return new CountryDto
            {
                Id = Country.Id,
                Name = Country.Name
            };
        }
        public async Task<bool> UpdateCountryAsync(int id, UpdateCountryDto updateCountryDto)
        {
            var CountryToUpdate = await _unitOfWork.CountryRepository.GetByIdAsync(id);

            if (CountryToUpdate is null)
                return false;

            if (updateCountryDto.Name is not null)
                CountryToUpdate.Name = updateCountryDto.Name;

            await _unitOfWork.SaveAsync();

            return true;
        }
        public async Task<bool> DeleteCountryAsync(int id)
        {
            var CountryToDelete = await _unitOfWork.CountryRepository.GetByIdAsync(id);

            if (CountryToDelete is null)
                return false;

            _unitOfWork.CountryRepository.Remove(CountryToDelete);

            await _unitOfWork.SaveAsync();

            return true;
        }

    }
}
