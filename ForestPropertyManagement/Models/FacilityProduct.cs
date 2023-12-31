using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class FacilityProduct
    {
        public int FacilityId { get; set; }
        public int Id { get; set; }
        public string FormerName { get; set; }
        public string Info { get; set; }
        public int CategoryId { get; set; }
        public Product Product
        {
            get
            {
                return new Product { Id = Id, FormerName = FormerName, Info = Info, CategoryId = CategoryId };
            }
        }
    }
}
