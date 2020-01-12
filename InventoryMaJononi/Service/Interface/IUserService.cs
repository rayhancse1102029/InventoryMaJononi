using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.Entity;

namespace InventoryMaJononi.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUser();
    }
}
