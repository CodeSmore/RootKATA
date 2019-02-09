using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RootDrivingHistoryKATA.tests
{
    [TestClass]
    public class DrivingHistoryTests
    {
        [TestMethod]
        public void Test001_GetTestDataFromInputFile()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData001.txt");

            Assert.AreEqual("Driver Peter Trip Peter 13:15 13:45 17.3", input);
        }

        [TestMethod]
        public void Test002_GetOutputDataForOneDriverWithoutDrivingData()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData003.txt");

            Assert.AreEqual("Peter: 0 miles", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test003_GetOutputDataForTwoDriversWithoutDrivingData()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData004.txt");

            Assert.AreEqual("Peter: 0 miles\nSamantha: 0 miles", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test004_GetOutputDataForOneDriverWithDrivingData()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData001.txt");

            Assert.AreEqual("Peter: 17 miles @ 35 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test005_GetOutputDataForTwoDriversEachWithOneTrip()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData002.txt");

            Assert.AreEqual("Samantha: 63 miles @ 42 mph\nPeter: 17 miles @ 35 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test006_GetOutputDataForTwoDriversEachWithTwoTrips()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData005.txt");

            Assert.AreEqual("Samantha: 84 miles @ 34 mph\nPeter: 39 miles @ 47 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test007_GivenDrivingHistoryWhenTripAverageSpeedFallsBelow5mphThenExcludeTripFromResults()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData006.txt");

            Assert.AreEqual("Samantha: 42 miles @ 34 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test008_GivenDrivingHistoryWhenTripAverageSpeedExceeds100mphThenExcludeTripFromResults()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData007.txt");

            Assert.AreEqual("Samantha: 42 miles @ 34 mph", drivingHistory.ToString(input));
        }
    }
}
