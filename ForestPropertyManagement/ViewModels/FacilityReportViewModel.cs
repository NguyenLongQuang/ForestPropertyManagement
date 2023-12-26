using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.ViewModels
{
    internal class FacilityReportViewModel : Base<FacilityReport>
    {
        int CategoryId;
        public int Month;
        public int Year;
        public int SelectedGroupId 
        {
            get => CategoryId;
            set
            {
                CategoryId = value;
                SelectedGroup = null;
            }
        }
        List<FacilityReport> SelectedGroup;
        public List<FacilityReport> SelectedGroupList
        {
            get
            {
                if (SelectedGroup == null)
                {
                    SelectedGroup = new List<FacilityReport>();
                    foreach (var rp in List)
                    {
                        if (rp.ReferenceId == SelectedGroupId && rp.RecordYear * 12 + rp.RecordMonth < Year * 12 + Month)
                        {
                            SelectedGroup.Add(rp);
                        }
                    }
                }
                return SelectedGroup;
            }
        }
    }
}
