using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Service
{
    public class UserService : IUserService
    {

        private readonly InventoryMaJononiDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(InventoryMaJononiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            var model = await _context.Users.ToListAsync();

            return model;
        }

        public async Task<ApplicationUser> GetUserInfoByUserEmail(string email)
        {

            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

           return user;

        }
    }
}
