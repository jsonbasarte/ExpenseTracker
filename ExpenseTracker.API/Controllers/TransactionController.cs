using AutoMapper;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.TransactionDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TransactionController : BaseController
{
    public TransactionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.Transaction.GetAll());
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerTransaction(int customerId)
    {
        return Ok(await _unitOfWork.Transaction.GetCustomerTransaction(customerId));
    }

    //[HttpGet("{transactionId}")]
    //public async Task<IActionResult> GetTranactionById(int transactionId)
    //{
    //    return Ok(await _unitOfWork.Transaction.GetById(transactionId));
    //}

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto request)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<TransactionDetails>(request);

        await _unitOfWork.Transaction.Add(result);
        await _unitOfWork.SaveAsync();

        return Ok(result);
    }
}
