using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.ViewModels
{
    internal class ProductViewModel : Base<Product>
    {
        int FacilityId = -1;
        int CategoryId = -1;
        public int GroupFacilityId
        {
            get => FacilityId;
            set
            {
                FacilityId = value;
                all = null;
            }
        }
        public int GroupCategoryId
        {
            get => CategoryId;
            set
            {
                CategoryId = value;
                all = null;
            }
        }
        public override List<Product> List
        {
            get
            {
                if (all == null && GroupFacilityId > 0 && GroupCategoryId > 0)
                {
                    List<FacilityProduct> tmp = new Base<FacilityProduct>().List;
                    all = new List<Product>();
                    foreach (var fProduct in tmp)
                    {
                        if (fProduct.FacilityId == GroupFacilityId && fProduct.CategoryId == GroupCategoryId)
                            all.Add(fProduct.Product);
                    }
                    return all;
                }
                else if (all == null && GroupFacilityId <= 0 && GroupCategoryId > 0)
                {
                    List<Product> tmp = new Base<Product>().List;
                    all = new List<Product>();
                    foreach (var product in tmp)
                    {
                        if (product.CategoryId == GroupCategoryId)
                            all.Add(product);
                    }
                    return all;
                }
                else if (all == null && GroupFacilityId <= 0 && GroupCategoryId <= 0)
                    return base.List;
                return all;

            }
        }
    }
}
