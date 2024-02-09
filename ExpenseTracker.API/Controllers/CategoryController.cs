using AutoMapper;
using ExpenseTracker.DataService.Interface.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{

    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _unitOfWork.Category.GetAll();

            return Ok();
        }
    }
}
