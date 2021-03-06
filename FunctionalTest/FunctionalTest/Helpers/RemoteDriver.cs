﻿using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace FunctionalTest.Helpers
{

    public class RemoteDriver
    {
        public static IWebDriver GetWebDriver(Browser browser)
        {
            var driver = GetTheDriver(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static IWebDriver GetTheDriver(Browser browser)
        {
            IWebDriver driver = GetCapabilityForDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }

        private static IWebDriver GetCapabilityForDriver(Browser browser)
        {
            var uri = new Uri(ConfigurationManager.AppSettings["SeleniumHubUrl"]);
            IWebDriver driver;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new RemoteWebDriver(uri, new ChromeOptions());
                    break;
                case Browser.InternetExplorer:
                    driver = new RemoteWebDriver(uri, new InternetExplorerOptions());
                    break;
                default:
                    driver = new RemoteWebDriver(uri, new FirefoxOptions());
                    break;
            }
            return driver;
        }
    }
}
