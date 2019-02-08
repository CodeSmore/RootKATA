using System;
using System.Collections.Generic;
using System.IO;
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
            return CombineDriverToStringsToSingleOutputString(GetDriversFromInput(input));
        }

        string CombineDriverToStringsToSingleOutputString(List<Driver> drivers)
        {
            string result = "";

            foreach (Driver driver in drivers)
            {
                if (result != "")
                {
                    result += '\n';
                }

                result += driver.ToString();
            }

            return result;
        }

        List<Driver> GetDriversFromInput(string input)
        {
            List<Driver> drivers = new List<Driver>();
            List<string> wordsFromInput = GetEachWordFromInput(input);

            for (int i = 0; i < wordsFromInput.Count; i += 2)
            {
                if (wordsFromInput[i] == "Driver")
                {
                    drivers.Add(new Driver(wordsFromInput[i + 1]));
                }

                if (wordsFromInput[i] == "Trip")
                {
                    string name = wordsFromInput[i + 1];

                    // get start time
                    float startHours;
                    int hour = int.Parse(wordsFromInput[i + 2].Substring(0, 2));
                    int minutes = int.Parse(wordsFromInput[i + 2].Substring(3));

                    startHours = hour + (float)minutes / 60;

                    // get end time
                    float endHours;
                    hour = int.Parse(wordsFromInput[i + 3].Substring(0, 2));
                    minutes = int.Parse(wordsFromInput[i + 3].Substring(3));

                    endHours = hour + (float)minutes / 60;

                    float totalHours = endHours - startHours;
                    float milesDriven = float.Parse(wordsFromInput[i + 4]);

                    foreach (Driver driver in drivers)
                    {
                        if (name == driver.Name)
                        {
                            driver.AddTripData(milesDriven, milesDriven / totalHours);
                        }
                    }
                }
            }

            return drivers;
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
