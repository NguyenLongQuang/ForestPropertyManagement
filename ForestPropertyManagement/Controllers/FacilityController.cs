using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.Controllers
{
    internal class FacilityController : ControllerBase
    {
        public object Index()
        {
            return View();
        }
        public object GroupByCategoryIndex(int CategoryId)
        {
            return View(CategoryId);
        }
        public object RecentDateIndex(int CategoryId, DateTime startDate, DateTime stopDate)
        {
            return View(CategoryId, startDate, stopDate);
        }
    }
}
