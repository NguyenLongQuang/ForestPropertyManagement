using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.Controllers
{
    internal class ProductController : ControllerBase
    {
        public object Index()
        {
            return View();
        }
        public object GroupByFacilityIndex(int FacilityId, int CategoryId)
        {
            return View(FacilityId, CategoryId);
        }
    }
}
