using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Models
{
   public class JourneyData
    {
        public int JourneyID { get; set; }
        public int DestinationID { get; set; }
        public DateTime DepartureTime { get; set; }
        public int PlatformNumber { get; set; }
    }
}
