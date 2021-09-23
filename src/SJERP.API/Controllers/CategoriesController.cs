
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SJERP.API.DTOs.Category;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace SJERP.API.Controllers
{
    [Route("api/[Controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        private CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CatgoryResultDto>>(categories));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var category = await _categoryService.GetById(Id);

            if (category == null) return NotFound();

            return Ok(_mapper.Map<CatgoryResultDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CatgoryAddDto catgoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(catgoryDto);
            var categoryResult = await _categoryService.Add(category);

            if (categoryResult == null) return BadRequest();

            return Ok(_mapper.Map<CatgoryResultDto>(categoryResult));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, CatgoryEditDto catgoryDto)
        {
            if (Id != catgoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.Update(_mapper.Map<Category>(catgoryDto));

            return Ok(catgoryDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var category = await _categoryService.GetById(Id);

            if (category == null) return NotFound();

            var result = await _categoryService.Remove(category);

            if (!result) return BadRequest();

            return Ok();
        }

        [Route("search/{category}")]
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Search(string category)
        {
            var categories = _mapper.Map<List<Category>>(await _categoryService.Search(category));

            if (categories == null || categories.Count == 0)
                return NotFound("None Category was founded");

            return Ok(categories);

        }

    }
}
