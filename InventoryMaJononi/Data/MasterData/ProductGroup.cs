using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using InventoryMaJononi.Data.Entity;

namespace InventoryMaJononi.Data.MasterData
{
    public class ProductGroup : Base
    {
        public string name { get; set; }
    }
}
