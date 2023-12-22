using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    internal class Description<T> where T : new()
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string FormerName { get; set; }
    }
}
