using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Areas.MasterData.Models;
using InventoryMaJononi.Data.MasterData;
using InventoryMaJononi.ServiceMasterData.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMaJononi.Areas.MasterData.Controllers
{
    [Area("Branch")]
    public class BranchController : Controller
    {

        private readonly IBranchService iBranchService;

        public BranchController(IBranchService iBranchService)
        {
            this.iBranchService = iBranchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BranchViewModel model)
        {

            var result = "error";

            Branch branch = new Branch
            {
                Id = model.Id,
                branchName = model.branchName,

            };

            if (model.Id != 0)
            {
                branch.updatedBy = User.Identity.Name;
                branch.updatedAt = DateTime.Now;

            }
            else
            {
                branch.createdBy = User.Identity.Name;
                branch.createdAt = DateTime.Now;
            }

            bool data = await iBranchService.SaveBranch(branch);

            if (data == true)
            {
                result = "success";
            }

            return View();
        }
    }
}