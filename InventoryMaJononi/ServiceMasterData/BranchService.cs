using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Data.MasterData;
using InventoryMaJononi.ServiceMasterData.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.ServiceMasterData
{

    public class BranchService : IBranchService
    {

        private readonly InventoryMaJononiDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public BranchService(InventoryMaJononiDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<bool> SaveBranch(Branch branch)
        {
            if (branch.Id != 0)
            {
                 _context.Branches.Update(branch);

                 await _context.SaveChangesAsync();

                 return true;
            }

            await _context.Branches.AddAsync(branch);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Branch>> GetAllBranch()
        {

            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _context.Branches.FindAsync(id);
        }

        public async Task<bool> DeleteBranchById(int id)
        {
             _context.Branches.Remove(_context.Branches.Find(id));

             await _context.SaveChangesAsync();

             return true;
        }
    }
}
