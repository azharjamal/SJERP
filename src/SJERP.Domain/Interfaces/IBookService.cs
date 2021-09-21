using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;

namespace SJERP.Domain.Interfaces
{
    public interface IBookService : IDisposable
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById(int Id);
        Task<Book> Add(Book book);

        Task<Book> Update(Book book);
        Task<bool> Remove(Book book);
        Task<IEnumerable<Book>> GetBookByCategory(int CategoryId);
        Task<IEnumerable<Book>> Search(string bookName);
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue);

    }
}
