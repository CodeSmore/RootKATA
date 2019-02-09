using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RootDrivingHistoryKATA.tests
{
    [TestClass]
    public class DrivingHistoryTests
    {
        [TestMethod]
        public void Test001_GivenDrivingHistoryInput_WhenInputIsStoredInTxtFile_ThenGetInputDataAsSingleString()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData001.txt");

            Assert.AreEqual("Driver Peter Trip Peter 13:15 13:45 17.3", input);
        }

        [TestMethod]
        public void Test002_GivenDrivingHistory_WhenInputIncludesOneDriverWithoutTripData_ThenGetOutputDataWithZeroMilesAndNoAverageSpeedIndicated()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData003.txt");

            Assert.AreEqual("Peter: 0 miles", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test003_GivenDrivingHistory_WhenInputIncludesTwoDriversWithoutTripData_ThenGetOutputDataForEachDriverWithZeroMilesAndNoAverageSpeedIndicated()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData004.txt");

            Assert.AreEqual("Peter: 0 miles\nSamantha: 0 miles", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test004_GivenDrivingHistory_WhenInputIncludesOneDriverWithOneTrip_ThenGetOutputDataIncludingTotalDistanceAndAverageSpeed()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData001.txt");

            Assert.AreEqual("Peter: 17 miles @ 35 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test005_GivenDrivingHistory_WhenInputIncludesTwoDriversEachWithOneTrip_ThenGetOutputDataIncludingTotalDistanceAndAverageSpeedForEachDriver()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData002.txt");

            Assert.AreEqual("Samantha: 63 miles @ 42 mph\nPeter: 17 miles @ 35 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test006_GivenDrivingHistory_WhenInputIncludesTwoDriversEachWithTwoTrips_ThenGetOutputDataIncludingTotalDistanceAndAverageSpeedForEachDriver()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData005.txt");

            Assert.AreEqual("Samantha: 84 miles @ 34 mph\nPeter: 39 miles @ 47 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test007_GivenDrivingHistory_WhenTripAverageSpeedFallsBelow5mph_ThenExcludeTripFromResults()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData006.txt");

            Assert.AreEqual("Samantha: 42 miles @ 34 mph", drivingHistory.ToString(input));
        }

        [TestMethod]
        public void Test008_GivenDrivingHistory_WhenTripAverageSpeedExceeds100mph_ThenExcludeTripFromResults()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData007.txt");

            Assert.AreEqual("Samantha: 42 miles @ 34 mph", drivingHistory.ToString(input));
        }
    }
}
