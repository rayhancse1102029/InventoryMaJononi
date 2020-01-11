using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMaJononi.Service.Interface
{
    public interface IEmployeeCodeService
    {
        Task<string> GetEmpCode();
    }
}
