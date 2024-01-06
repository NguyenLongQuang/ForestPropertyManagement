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
        public object Index(int a)
        {
            return View(a);
        }
        public object GroupByFacilityIndex(int FacilityId, int CategoryId)
        {
            return View(FacilityId, CategoryId);
        }
        public object GroupByCategoryIndex(int CategoryId)
        {
            return View(CategoryId);
        }
    }
}
