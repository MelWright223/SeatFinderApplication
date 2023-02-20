using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Models
{
    public class StationData
    {
       public int StationID { get; set; }
        public string StationName { get; set; }
        public int MaximumCarriageSpace { get; set; }
        public double StationLat { get; set; }
        public double StationLong { get; set; }
       // public int JourneyID { get; set; }
        //public int Platform { get; set; }
        //public int DestinationStationID { get; set; }
       // public DateTime Time { get; set; }

        
    }
}
