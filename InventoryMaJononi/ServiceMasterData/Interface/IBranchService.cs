using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.MasterData;

namespace InventoryMaJononi.ServiceMasterData.Interface
{
    public interface IBranchService
    {
        Task<bool> SaveBranch(Branch branch);
        Task<IEnumerable<Branch>> GetAllBranch();
        Task<Branch> GetBranchById(int id);
        Task<bool> DeleteBranchById(int id);
    }
}
