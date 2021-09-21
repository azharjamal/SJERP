using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;


namespace SJERP.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        new Task<List<Book>> GetAll();

        new Task<Book> GetById(int Id);

        Task<IEnumerable<Book>> GetBooksByCategory(int CategoryId);
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchvalue);

    }
}
