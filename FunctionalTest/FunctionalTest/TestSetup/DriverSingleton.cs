using System;
using System.Configuration;
using FunctionalTest.Helpers;
using OpenQA.Selenium;

namespace FunctionalTest.TestSetup
{
    public static class DriverSingleton
    {
        private static IWebDriver _driver;
        private static readonly Object DriverLock = new object();

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    lock (DriverLock)
                    {
                        if (_driver == null)
                        {
                            var isLocal = bool.Parse(ConfigurationManager.AppSettings["isLocal"]);
                            var browser = ConfigurationManager.AppSettings["Browser"].AsEnum<Browser>();
                            _driver = (isLocal)
                                ? LocalDriver.GetWebDriver(browser)
                                : RemoteDriver.GetWebDriver(browser);
                        }
                    }
                }

                return _driver;
            }
        }
    }
}
