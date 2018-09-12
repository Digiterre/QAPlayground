using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;

namespace FunctionalTest.TestSetup
{
    [Binding]
    public class FixtureBase
    {
        [AfterScenario()]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            Screenshot ss = DriverSingleton.Driver.TakeScreenshot();
            ss.SaveAsFile(GetTheFileName(), ScreenshotImageFormat.Jpeg);
            DriverTearDown();

        }


        private static string GetTheFileName()
        {
            var location = @"C:/Temp/FunctionalTestScreenshots";
            Directory.CreateDirectory(location);
            var fileName = $"Failure_{DateTime.UtcNow.ToFileTimeUtc()}.jpg";
            return Path.Combine(location, fileName);
        }

        [AfterTestRun]
        public static void DriverTearDown()
        {
            DriverSingleton.Driver.Close();
            DriverSingleton.Driver.Quit();
            DriverSingleton.Driver.Dispose();
        }
    }
}
