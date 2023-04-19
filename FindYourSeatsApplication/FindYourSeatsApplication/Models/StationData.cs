using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FindYourSeatsApplication.Models
{
    public class StationData
    {
       public int StationID { get; set; }
        public string StationName { get; set; }
        public int MaximumCarriageSpace { get; set; }
        public double StationLat { get; set; }
        public double StationLong { get; set; }

        public Location stationLocation { get; set; }


        public double GetOverallLoc(double stationLat)
        {
         
            return stationLat;
        }

    }
    
}
