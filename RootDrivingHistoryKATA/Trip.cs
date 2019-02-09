using System;
using System.Collections.Generic;
using System.Text;

namespace RootDrivingHistoryKATA
{
    public class Trip
    {
        public string DriverName { get; set; }
        public float AverageSpeedInMPH { get; set; }
        public float DistanceInMiles { get; set; }

        public Trip(string driverName, float averageSpeedInMPH, float distanceInMiles)
        {
            DriverName = driverName;
            AverageSpeedInMPH = averageSpeedInMPH;
            DistanceInMiles = distanceInMiles;
        }
    }
}
