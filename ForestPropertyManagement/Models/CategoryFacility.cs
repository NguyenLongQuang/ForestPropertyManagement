using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class CategoryFacility
    {
        public int CategoryId { get; set; }
        public int Id { get; set; }
        public string FormerName { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime DissolvedDate { get; set; }
        public int DistrictId { get; set; }
        public int BusinessStructureId { get; set; }
        public Facility Facility
        {
            get
            {
                return new Facility { Id = Id, FormerName = FormerName
                                    , EstablishedDate = EstablishedDate
                                    , DissolvedDate = DissolvedDate
                                    , DistrictId = DistrictId
                                    , BusinessStructureId = BusinessStructureId};
            }
        }
    }
}
