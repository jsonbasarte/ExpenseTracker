﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataService.Models;

public class ApplicationRole : IdentityRole<int>
{
    public ApplicationRole()
    {

    }

    public ApplicationRole(string roleName) : base(roleName)
    {

    }
}