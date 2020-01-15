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
    [Area("MasterData")]
    public class BranchController : Controller
    {

        private readonly IBranchService iBranchService;

        public BranchController(IBranchService iBranchService)
        {
            this.iBranchService = iBranchService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            BranchViewModel model = new BranchViewModel
            {
                branches = await iBranchService.GetAllBranch()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BranchViewModel model)
        {

            var result = "error";

            if (!ModelState.IsValid)
            {
                return Json(result);
            }

            Branch branch = new Branch
            {
                Id = model.Id,
                branchName = model.branchName,
                createdBy = User.Identity.Name,
                createdAt = DateTime.Now

            };

            bool data = await iBranchService.SaveBranch(branch);

            if (data == true)
            {
                result = "success";
            }

            return Json(result);
        }
    }
}