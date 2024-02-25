using AutoMapper;
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.Wallet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class WalletController : BaseController
{
    public WalletController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customer = await _unitOfWork.Wallet.GetAll();

        return Ok(customer);
    }

    [HttpGet("{walletId}")]
    public async Task<IActionResult> GetWalletById(int walletId)
    {
        return Ok(await _unitOfWork.Wallet.GetById(walletId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWalletDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Wallet>(request);

        await _unitOfWork.Wallet.Add(result);

        await _unitOfWork.SaveAsync();

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWallet([FromBody] UpdateWalletDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Wallet>(request);

        await _unitOfWork.Wallet.Update(result);

        await _unitOfWork.SaveAsync();

        return Ok(request);
    }

}
