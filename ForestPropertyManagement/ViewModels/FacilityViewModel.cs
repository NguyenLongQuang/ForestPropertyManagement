using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ForestPropertyManagement.ViewModels
{
    internal class FacilityViewModel : Base<Facility>
    {
        int CategoryId;
        public DateTime StartDate;
        public DateTime StopDate;
        public int GroupCategoryId
        {
            get => CategoryId;
            set
            {
                CategoryId = value;
                all = null;
            }
        }
        public override List<Facility> List
        {
            get
            {
                if( all == null && GroupCategoryId > 0)
                {
                    List<CategoryFacility> tmp = new Base<CategoryFacility>().List;
                    all = new List<Facility>();
                    foreach(var cFacility in tmp)
                    {
                        if (cFacility.CategoryId == GroupCategoryId)
                            all.Add(cFacility.Facility);
                    }
                    return all;
                }
                else if (all == null && GroupCategoryId <= 0)
                    return base.List;
                
                return all;

            }
        }
        public List<Facility> GroupByDateList
        {
            get
            {
                if (StartDate == null)
                    return List;
                else
                {
                    List<Facility> date = new List<Facility>();
                    foreach (Facility facility in List)
                    {
                        if(facility.EstablishedDate <= StopDate && facility.DissolvedDate >= StartDate) 
                        {
                            date.Add(facility);
                        }
                    }
                    return date;
                }
            }
        }
    }
}
