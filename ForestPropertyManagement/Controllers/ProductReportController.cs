﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.Controllers
{
    internal class ProductReportController : ControllerBase
    {
        public object GroupByProductIndex(int productId)
        {
            return View(productId);
        }
    }
}