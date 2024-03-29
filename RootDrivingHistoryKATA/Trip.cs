﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RootDrivingHistoryKATA
{
    public class Trip
    {
        public string DriverName { get; set; }
        public float TimeInHours { get; set; }
        public float DistanceInMiles { get; set; }

        public Trip(string driverName, float timeInHours, float distanceInMiles)
        {
            if (distanceInMiles / timeInHours > 100 || distanceInMiles / timeInHours < 5)
            {
                timeInHours = 0;
                distanceInMiles = 0;
            }

            DriverName = driverName;
            TimeInHours = timeInHours;
            DistanceInMiles = distanceInMiles;
        }
    }
}
