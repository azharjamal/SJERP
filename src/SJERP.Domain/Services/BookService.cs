using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;
using SJERP.Domain.Interfaces;
using System.Linq;

namespace SJERP.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(int Id)
        {
            return await _bookRepository.GetById(Id);
        }

        public async Task<Book> Add(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name).Result.Any())
                return null;

            await _bookRepository.Add(book);
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name && b.Id == book.Id).Result.Any())
                return null;

            await _bookRepository.Update(book);
            return book;
        }

        public async Task<bool> Remove(Book book)
        {

            await _bookRepository.Remove(book);
            return true;
        }

        public async Task<IEnumerable<Book>> GetBookByCategory(int categoryId)
        {
            return await _bookRepository.GetBooksByCategory(categoryId);
        }

        public async Task<IEnumerable<Book>> Search(string bookName)
        {
            return await _bookRepository.Search(b => b.Name.Contains(bookName));
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchValue)
        {
            return await _bookRepository.SearchBookWithCategory(searchValue);
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }
    }

}
