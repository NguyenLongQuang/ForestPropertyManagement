using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ForestPropertyManagement.ViewModels
{
    internal class FacilityAddressViewModel : Base<FacilityAddress>
    {
        public static int SelectedGroupId = 1;
        List<FacilityAddress> SelectedGroup;
        public List<FacilityAddress> SelectedGroupList
        {
            get
            {
                if (SelectedGroup == null)
                {
                    SelectedGroup = new Provider().Select<FacilityAddress>($"SELECT * FROM {typeof(FacilityAddress).Name} WHERE CategoryId={SelectedGroupId};");
                }
                return SelectedGroup;
            }
        }
    }
}
