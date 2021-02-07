using Gauge.CSharp.Lib;

namespace UIAutomationChallenge.Utils
{
    public class Utility
    {
        public void TakeScreenshot() => GaugeScreenshots.Capture();

        public static string GetUsernameFromCSV(){
            var users = DataGenerator.GetTestDataFromCsvFile();
			string username = users[0].FirstName + " " + users[0].LastName;
            return username;
        }
    }
}
