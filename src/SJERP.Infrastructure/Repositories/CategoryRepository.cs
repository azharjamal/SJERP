using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using SJERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace SJERP.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(SJERPDbContext context) : base(context) { }
    }
}
