﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ForestPropertyManagement.ViewModels
{
    internal class FacilityAddressViewModel : Base<FacilityAddress>
    {
        int CategoryId;
        public int SelectedGroupId
        {
            get => CategoryId;
            set
            {
                CategoryId = value;
                SelectedGroup = null;
            }
        }
        List<FacilityAddress> SelectedGroup;
        public List<FacilityAddress> SelectedGroupList
        {
            get
            {
                if (SelectedGroup == null)
                {
                    SelectedGroup = new List<FacilityAddress>();
                    foreach (var rp in List)
                    {
                        if (rp.CategoryId == SelectedGroupId)
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
