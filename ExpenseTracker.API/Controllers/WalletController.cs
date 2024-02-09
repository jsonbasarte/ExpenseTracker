using AutoMapper;
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;


public class WalletController : BaseController
{
    public WalletController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customer = await _unitOfWork.Category.GetAll();

        return Ok();
    }
}
