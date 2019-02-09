using System;
using System.Collections.Generic;
using System.Text;

namespace RootDrivingHistoryKATA
{
    public class Driver
    {
        public string Name { get; }
        public float MilesDriven { get; set; }
        private float AverageSpeedInMPH { get; set; }

        public Driver(string name)
        {
            Name = name;
            MilesDriven = 0;
        }

        public void AddTripData(float milesDriven, float avgSpeed)
        {
            MilesDriven = milesDriven;
            AverageSpeedInMPH = avgSpeed;
        }

        public override string ToString()
        {
            string returnString = "";

            returnString += Name + ": " + Math.Round(MilesDriven) + " miles";

            if (MilesDriven > 0)
            {
                returnString += " @ " + Math.Round(AverageSpeedInMPH) + " mph";
            }

            return  returnString;
        }
    }
}
