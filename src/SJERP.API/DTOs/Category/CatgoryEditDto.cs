using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SJERP.API.DTOs.Category
{
    public class CatgoryEditDto
    {
        [Required(ErrorMessage =" The field {0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The filed {0} is required")]
        [StringLength(150, ErrorMessage ="The filed {0} must be between {2} and {1} characters")]
        public string Name { get; set; }
    }
}
