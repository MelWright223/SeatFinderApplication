using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Models
{
    class StationData
    {
        int StationID { get; set; }
        string StationName { get; set; }
        int MaximumCarriageSpace { get; set; }
        string StationLat { get; set; }
        string StationLong { get; set; }
        int JourneyID { get; set; }
        int Platform { get; set; }
        int DestinationStationID { get; set; }
        DateTime Time { get; set; }

        
    }
}
