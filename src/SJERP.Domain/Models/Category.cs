using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        
        /* EF Relationship */
        public IEnumerable<Book> Books { get; set; }
    }
}
