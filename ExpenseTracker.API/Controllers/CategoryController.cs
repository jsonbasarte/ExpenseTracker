using AutoMapper;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.Category;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAll();

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            return Ok(await _unitOfWork.Category.GetById(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _mapper.Map<Category>(request);

            await _unitOfWork.Category.Add(result);

            await _unitOfWork.SaveAsync();

            return Ok(result);
        }
    }
}
