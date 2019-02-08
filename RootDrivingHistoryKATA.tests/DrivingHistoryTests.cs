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
        public void Test002_GetOutputData()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData001.txt");

            Assert.AreEqual("Peter: 17 miles @ 37 mph", drivingHistory.ToString());
        }

        [TestMethod]
        public void Test003_GetOutputDataUsingSecondTestDataFileUsingADifferentDriver()
        {
            DrivingHistory drivingHistory = new DrivingHistory();

            string input = drivingHistory.GetInputData("TestData002.txt");

            Assert.AreEqual("Samantha: 63 miles @ 42 mph", drivingHistory.ToString());
        }
    }
}
