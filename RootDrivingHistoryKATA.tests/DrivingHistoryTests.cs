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
    }
}
