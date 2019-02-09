using System;

namespace RootDrivingHistoryKATA
{
    public class Driver
    {
        public string Name { get; }
        public float MilesDriven { get; set; }
        private float HoursDriven { get; set; }

        public Driver(string name)
        {
            Name = name;
            MilesDriven = 0;
        }

        public void AddTripData(float milesDriven, float hoursDriven)
        {
            MilesDriven += milesDriven;
            HoursDriven += hoursDriven;
        }

        public override string ToString()
        {
            string returnString = "";

            returnString += Name + ": " + Math.Round(MilesDriven) + " miles";

            if (MilesDriven > 0)
            {
                returnString += " @ " + Math.Round(MilesDriven / HoursDriven) + " mph";
            }

            return  returnString;
        }
    }
}
