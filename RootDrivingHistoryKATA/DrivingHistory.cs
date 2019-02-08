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
            // C:\Users\codes\source\repos\KATAs\KATAs.Data

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
            string result = "";
            List<Driver> drivers = new List<Driver>();

            List<string> wordsFromInput = new List<string>();
            string a = "";

            foreach (char character in input)
            {
                if (character != ' ')
                {
                    a += character;
                }
                else
                {
                    wordsFromInput.Add(a);
                    a = "";
                }
            }
            wordsFromInput.Add(a);

            for (int i = 0; i < wordsFromInput.Count; i += 2)
            {
                if (wordsFromInput[i] == "Driver")
                {
                    drivers.Add(new Driver(wordsFromInput[i+1]));
                }
            }

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
    }
}
