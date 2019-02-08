using System;
using System.Collections.Generic;
using System.Text;

namespace RootDrivingHistoryKATA
{
    public class Driver
    {
        string Name { get; }
        int MilesDriven { get; }
        int AverageSpeedInMPH { get; }

        public Driver(string name, int milesDriven, int avgSpeed)
        {
            Name = name;
            MilesDriven = milesDriven;
            AverageSpeedInMPH = avgSpeed;
        }

        public override string ToString()
        {
            return Name + ": " + MilesDriven + " miles @ " + AverageSpeedInMPH + " mph";
        }
    }
}
