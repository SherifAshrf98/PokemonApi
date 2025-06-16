using Microsoft.Extensions.Caching.Memory;
using PokemonApi.Application.Dtos.CategoryDtos;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var Categories = await _unitOfWork.CategoryRepository.GetAllAsync();

            if (Categories == null)
                return null;

            var CategoriesDto = Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
            });

            return CategoriesDto;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var Category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            if (Category == null)
                return null;

            return new CategoryDto
            {
                Id = Category.Id,
                Name = Category.Name,
            };
        }

        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var ExsistingCategory = await _unitOfWork.CategoryRepository.FindAsync(c => c.Name == createCategoryDto.Name);

            if (ExsistingCategory is not null)
                throw new InvalidOperationException("This Country already Exists");

            var NewCategory = new Category
            {
                Name = createCategoryDto.Name,
            };

            var AddedCategory = await _unitOfWork.CategoryRepository.AddAsync(NewCategory);

            await _unitOfWork.SaveAsync();

            return new CategoryDto
            {
                Id = AddedCategory.Id,
                Name = AddedCategory.Name,
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var CurrentCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            if (CurrentCategory is null)
                return false;

            if (updateCategoryDto.Name is not null)
                CurrentCategory.Name = updateCategoryDto.Name;

            await _unitOfWork.SaveAsync();

            return true;

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var CurrentCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            if (CurrentCategory is null)
                return false;

            _unitOfWork.CategoryRepository.Remove(CurrentCategory);

            await _unitOfWork.SaveAsync();

            return true;
        }

    }
}
