﻿using IdentityContext.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class IdentityContext: IdentityDbContext<ApplicationUser>
    {
     
            public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
            {

            }
        
    }
}
