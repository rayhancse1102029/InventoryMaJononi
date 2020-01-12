using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Service
{
    public class UserService : IUserService
    {

        private readonly InventoryMaJononiDbContext _context;

        public UserService(InventoryMaJononiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            var model = await _context.Users.ToListAsync();

            return model;
        }
    }
}
