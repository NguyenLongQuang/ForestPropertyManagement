﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Facility
    {
        public int Id { get; set; }
        public string FormerName { get; set; }
        //public DateTime Established;
        //public float Longtitute { get; set; }
        //public float Latitute { get; set; }

    }
    internal class FacilityList : List<Facility>
    {
        public FacilityList()
        {
            this.AddRange(new Provider().Select<Facility>("SELECT * FROM Facility"));
        }
    }
}