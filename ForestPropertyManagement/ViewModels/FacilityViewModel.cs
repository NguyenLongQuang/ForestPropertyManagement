﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ForestPropertyManagement.ViewModels
{
    internal class FacilityViewModel : Base<Facility>
    {
        public static int SelectedGroupId = 1;
        List<Facility> SelectedGroup;
        public List<Facility> SelectedGroupList
        {
            get
            {
                if(SelectedGroup == null)
                {
                    SelectedGroup = new Provider().Select<Facility>($"SELECT * FROM {typeof(Facility).Name} WHERE Id IN (SELECT {typeof(Facility).Name}Id FROM Offering WHERE CategoryId = {SelectedGroupId});");
                }
                return SelectedGroup;
            }
        }
    }
}
