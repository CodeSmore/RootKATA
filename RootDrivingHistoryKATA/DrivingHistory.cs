using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RootDrivingHistoryKATA
{
    public class DrivingHistory
    {
        public string GetInputData(string fileName)
        {
            string fileContentsAsString = "";

            string workingDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string subfolderPath = @"Kata.Data";

            string filePath = Path.Combine(solutionDirectory, subfolderPath, fileName);

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    // Read in the line
                    fileContentsAsString += sr.ReadLine();

                    if (!sr.EndOfStream)
                    {
                        fileContentsAsString += " ";
                    }
                }
            }

            return fileContentsAsString;
        }

        public string ToString(string input)
        {
            return CombineDriverToStringsToSingleOutputString(ExtractDrivingHistoryFromInput(input));
        }

        string CombineDriverToStringsToSingleOutputString(List<Driver> drivers)
        {
            string result = "";
            List<Driver> sortedDriversList = drivers.OrderByDescending(o => o.MilesDriven).ToList();

            foreach (Driver driver in sortedDriversList)
            {
                if (result != "")
                {
                    result += '\n';
                }

                result += driver.ToString();
            }

            return result;
        }

        List<Driver> ExtractDrivingHistoryFromInput(string input)
        {
            List<Driver> drivers = new List<Driver>();
            List<string> wordsFromInput = GetEachWordFromInput(input);

            for (int i = 0; i < wordsFromInput.Count; ++i)
            {
                if (wordsFromInput[i] == "Driver")
                {
                    drivers.Add(new Driver(wordsFromInput[i + 1]));
                }

                if (wordsFromInput[i] == "Trip")
                {
                    Trip trip = ConvertDataToTrip(wordsFromInput, i);
                    

                    // store trip data
                    foreach (Driver driver in drivers)
                    {
                        if (trip.DriverName == driver.Name)
                        {
                            driver.AddTripData(trip.DistanceInMiles, trip.TimeInHours);
                        }
                    }
                }
            }

            return drivers;
        }

        Trip ConvertDataToTrip(List<string> wordsFromInput, int index)
        {
            // extract trip data
            string name = wordsFromInput[index + 1];

            // get start time
            float startHours;
            int hour = int.Parse(wordsFromInput[index + 2].Substring(0, 2));
            int minutes = int.Parse(wordsFromInput[index + 2].Substring(3));

            startHours = hour + (float)minutes / 60;

            // get end time
            float endHours;
            hour = int.Parse(wordsFromInput[index + 3].Substring(0, 2));
            minutes = int.Parse(wordsFromInput[index + 3].Substring(3));

            endHours = hour + (float)minutes / 60;

            float totalHours = endHours - startHours;
            float milesDriven = float.Parse(wordsFromInput[index + 4]);

            return new Trip(name, totalHours, milesDriven);
        }

        List<string> GetEachWordFromInput(string input)
        {
            List<string> result = new List<string>();
            string word = "";

            foreach (char character in input)
            {
                if (character != ' ')
                {
                    word += character;
                }
                else
                {
                    result.Add(word);
                    word = "";
                }
            }
            result.Add(word);

            return result;
        }
    }
}
