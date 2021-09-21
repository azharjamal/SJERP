using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SJERP.Domain.Models;

namespace SJERP.Domain.Interfaces
{
    public interface ICategoryService: IDisposable
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int Id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Remove(Category category);
        Task<IEnumerable<Category>> Search(string categoryName);



    }
}
