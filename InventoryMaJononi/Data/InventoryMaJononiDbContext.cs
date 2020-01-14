using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Data.MasterData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Data
{
    public class InventoryMaJononiDbContext : IdentityDbContext<ApplicationUser>
    {

        public InventoryMaJononiDbContext(DbContextOptions<InventoryMaJononiDbContext> options) : base(options)
        {

        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }

    }


}
