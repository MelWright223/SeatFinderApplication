using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindYourSeatsAPI.Models
{
    public class StationData
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public int MaximumCarriageSpace { get; set; }
        public double StationLat { get; set; }
        public double StationLong { get; set; }

        public string stationLocation { get; set; }
    }
}
