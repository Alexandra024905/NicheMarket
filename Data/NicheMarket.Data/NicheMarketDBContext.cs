﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NicheMarket.Data.Models.Users;
using NicheMarket.Data.Models;

namespace NicheMarket.Data
{
    public class NicheMarketDBContext : IdentityDbContext<NicheMarketUser, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }

        //public DbSet<Retailer> Retailers { get; set; }

        //public DbSet<Client> Clients { get; set; }

        //public DbSet<Admin> Admins { get; set; }
        public NicheMarketDBContext(DbContextOptions<NicheMarketDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
