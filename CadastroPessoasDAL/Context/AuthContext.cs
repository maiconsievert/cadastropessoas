﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoasDAL.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("name=DefaultConnection")
        {

        }

        //public DbSet<Client> Clients { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
