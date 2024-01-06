using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string FormerName { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime DissolvedDate { get; set; }
        public int DistrictId { get; set; }
        public int BusinessStructureId { get; set; }
        public bool IsValid() { if ( FormerName == null || EstablishedDate == null || DissolvedDate == null || DistrictId <= 0 || BusinessStructureId <= 0) return false; return true; }
        public List<Description<Facility>> GetFullDetail() => new List<Description<Facility>> { new Provider().Select<Description<Facility>>($"SELECT * FROM District where Id={DistrictId}")[0],
                                                                                              new Provider().Select<Description<Facility>>($"SELECT * FROM BusinessStructure where Id={BusinessStructureId}")[0] };
    }
    internal class FacilityList : List<Facility>
    {
        public FacilityList()
        {
            this.AddRange(new Provider().Select<Facility>("SELECT * FROM Facility"));
        }
    }
}
