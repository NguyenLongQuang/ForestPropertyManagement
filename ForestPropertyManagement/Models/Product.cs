using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Product : Description<Category>
    {
        public int CategoryId { get; set; }
        public Category GetCategory()
        {
            return new Provider().Select<Category>($"SELECT * FROM {typeof(Category).Name} WHERE Id = {CategoryId}")[0];
        }
    }
}
