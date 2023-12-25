using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class FacilityAddress
    {
        public int CategoryId { get; set; }
        public string FacilityName { get; set; }
        public string DistrictName { get; set; }
    }
    internal class FacilityAddressList : List<FacilityAddress>
    {
        public FacilityAddressList()
        {
            this.AddRange(new Provider().Select<FacilityAddress>("SELECT * FROM FacilityAddress"));
        }
    }
}
