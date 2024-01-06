using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace ForestPropertyManagement.ViewModels
{
    internal class ProductReportViewModel : Base<ProductReport>
    {
        int ProductId;
        public int GroupProductId
        {
            get => ProductId;
            set
            {
                ProductId = value;
                all = null;
            }
        }
        public override List<ProductReport> List
        {
            get
            {
                if (all == null && GroupProductId > 0)
                {
                    all = base.List.Where(item => item.ReferenceId == ProductId).ToList();
                    return all;
                }
                else if (all == null && GroupProductId <= 0)
                    return base.List;
                return all;
            }
        }
    }
}
