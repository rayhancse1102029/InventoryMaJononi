using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.MasterData;

namespace InventoryMaJononi.Areas.MasterData.Models
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string branchName { get; set; }


        public IEnumerable<Branch> branches { get; set; }
    }
}
