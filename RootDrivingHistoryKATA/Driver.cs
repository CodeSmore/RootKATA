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

        public Driver(string name)
        {
            Name = name;
            MilesDriven = 0;
        }

        public override string ToString()
        {
            return Name + ": " + MilesDriven + " miles" ;
        }
    }
}
