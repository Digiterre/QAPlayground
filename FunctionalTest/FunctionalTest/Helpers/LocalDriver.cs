using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace FunctionalTest.Helpers
{
    public static class LocalDriver
    {
        internal static IWebDriver GetWebDriver(Browser browser)
        {
            var driver = GetDriver(browser);
            return  driver;
        }

        private static IWebDriver GetDriver(Browser browser)
        {
            IWebDriver driver = GetCapabilityFor(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }
        private static IWebDriver GetCapabilityFor(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.InternetExplorer:
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }

    }
}
