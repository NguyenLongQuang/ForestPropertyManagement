using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.Controllers
{
    internal class FacilityReportController : ControllerBase
    {
        public object Index()
        {
            return View();
        }
        public object SelectedGroupIndex(int CategoryId, int Month, int Year)
        {
            return View(CategoryId, Month, Year);
        }
    }
}
