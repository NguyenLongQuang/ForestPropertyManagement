using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    public class Description<T> where T : new()
    {
        public int Id { get; set; }
        public string FormerName { get; set; }
        public string Info { get; set; }
    }
}
