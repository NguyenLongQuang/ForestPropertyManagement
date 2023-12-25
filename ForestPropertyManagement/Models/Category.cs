using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string FormerName { get; set; }
    }
    internal class CategoryList : List<Facility>
    {
        public CategoryList()
        {
            this.AddRange(new Provider().Select<Facility>("SELECT * FROM Category"));
        }
    }
}
