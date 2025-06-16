using PokemonApi.Application.Dtos.OwnerDtos;
using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Application.Interfaces.Services;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Implementation.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OwnerDto> AddOwnerAsync(CreateOwnerDto createOwnerDto)
        {
            var ExisitingOwner = await _unitOfWork.OwnerRepository.FindAsync(owner => owner.FirstName == createOwnerDto.FirstName
                                                                             && owner.LastName == createOwnerDto.LastName
                                                                             && owner.Gym == createOwnerDto.Gym);
            if (ExisitingOwner is not null)
                throw new InvalidOperationException($"An Owner Already Exists with the Same Data");

            var NewOwner = new Owner
            {
                FirstName = createOwnerDto.FirstName,
                LastName = createOwnerDto.LastName,
                Gym = createOwnerDto.Gym,
                CountryId = createOwnerDto.CountryID
            };

            var Owner = await _unitOfWork.OwnerRepository.AddAsync(NewOwner);

            await _unitOfWork.SaveAsync();

            return new OwnerDto
            {
                Id = Owner.Id,
                FirstName = Owner.FirstName,
                LastName = Owner.LastName,
                Gym = Owner.Gym,
            };
        }

        public async Task<bool> UpdateOwnerAsync(int id, UpdateOwnerDto updateOwnerDto)
        {
            var Owner = await _unitOfWork.OwnerRepository.GetByIdAsync(id);

            if (Owner is null)
                return false;

            if (updateOwnerDto.FirstName is not null)
                Owner.FirstName = updateOwnerDto.FirstName;

            if (updateOwnerDto.LastName is not null)
                Owner.LastName = updateOwnerDto.LastName;

            if (updateOwnerDto.Gym is not null)
                Owner.Gym = updateOwnerDto.Gym;

            if (updateOwnerDto.CountryID.HasValue)
                Owner.CountryId = updateOwnerDto.CountryID.Value;

            await _unitOfWork.SaveAsync();

            return true;
        }
        public async Task<bool> DeleteOwnerAsync(int id)
        {
            var OwnerToDelete = await _unitOfWork.OwnerRepository.GetByIdAsync(id);

            if (OwnerToDelete is null)
                return false;

            _unitOfWork.OwnerRepository.Remove(OwnerToDelete);

            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
        {
            var Owners = await _unitOfWork.OwnerRepository.GetAllWithIncludesAsync(o => o.Country);

            if (Owners == null)
                return null;

            var OwnersDto = Owners.Select(owner => new OwnerDto
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Gym = owner.Gym,
                CountryName = owner.Country.Name
            });

            return OwnersDto;
        }
        public async Task<OwnerDto> GetOwnerAsync(int ownerId)
        {
            var owner = await _unitOfWork.OwnerRepository.GetWithIncludesAsync(o => o.Id == ownerId, o => o.Country);

            if (owner is null)
                return null;

            var ownerDto = new OwnerDto
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Gym = owner.Gym,
                CountryName = owner.Country.Name
            };

            return ownerDto;
        }

    }
}
