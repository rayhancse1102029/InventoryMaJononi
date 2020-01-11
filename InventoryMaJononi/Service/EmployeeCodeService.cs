using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Service
{
    public class EmployeeCodeService : IEmployeeCodeService
    {

        private readonly InventoryMaJononiDbContext _context;

        public EmployeeCodeService(InventoryMaJononiDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetEmpCode()
        {
            int year = DateTime.Now.Year;

            int maxId = await _context.Users.CountAsync() + 1;

            string getEmpCode = "MaJononi/" + year + "/" + maxId;


            return getEmpCode;
        }
    }
}
