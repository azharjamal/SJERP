﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;
using SJERP.Domain.Interfaces;
using System.Linq;

namespace SJERP.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookService _bookService;


        public CategoryService(ICategoryRepository categoryRepository, IBookService bookService )
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int Id)
        {
            return await _categoryRepository.GetById(Id);
        }

        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);

            return category;
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id == category.Id).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Remove(Category category)
        {
            var books = await _bookService.GetBookByCategory(category.Id);
            if (books.Any()) return false;

            await _categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(categoryName));

        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}