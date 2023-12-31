using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    internal class Report<T> where T : new()
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public int Number { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
