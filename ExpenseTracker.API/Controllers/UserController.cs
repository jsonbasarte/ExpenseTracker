using AutoMapper;
using ExpenseTracker.DataService.Data;
using ExpenseTracker.DataService.Interface.Repo;
using ExpenseTracker.DataService.Models;
using ExpenseTracker.Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExpenseTracker.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : BaseController
{
    private readonly ApplicationDbContext _dbContext;
    public UserController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext dbContext) : base(unitOfWork, mapper)
    {
        _dbContext = dbContext;
    }

    [HttpGet("current-user")]
    public async Task<object> GetCurrentUser()
    {
        string email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        return Ok(new CurrentUserModel()
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Email = result.Email
        });
    }
}
