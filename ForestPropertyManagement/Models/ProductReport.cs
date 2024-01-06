using Models;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class ProductReport : Report<Product>
    {
        public string RecordDateDDMMYY
        {
            get
            {
                return $"{RecordDate.Day}/{RecordDate.Month}/{RecordDate.Year}";
            }
        }
    }
}
