﻿using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Entities.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName {  get; set; } = string.Empty;
    public string LastName {  get; set; } = string.Empty;
}
