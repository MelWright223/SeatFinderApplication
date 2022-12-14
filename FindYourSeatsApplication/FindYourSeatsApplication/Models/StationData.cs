using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Models
{
    class StationData
    {
        int JourneyID { get; set; }
        int Platform { get; set; }
        int DestinationStationID { get; set; }
        DateTime Time { get; set; }
        
    }
}
