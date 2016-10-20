using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using SeleniumWebdriverProject_Tests.Helpers;


namespace SeleniumWebdriverProject_Tests
{
    [TestFixture]
    [Parallelizable()]
    public class HeroPage 
    {
        private IWebDriver _driver;
        private Helper helper;
        private static string[] browsers = ConfigurationManager.AppSettings["Browsers"].Split(',');
        private string browser;

        public static IEnumerable<string> GetBrowser
        {
            get
            {
                foreach (var selectedBrowser in browsers)
                {
                    yield return selectedBrowser;
                }
            }
        }

        //[Factory("GetBrowser")]
        //public HeroPage(string browser)
        //{
        //    this.browser = browser;
        //}


        //[TestCase("GetBrowser")]
        public HeroPage()
        {
            this.browser = "chrome";
        }



        [SetUp]
        public void Setup()
        {
            
            helper = new Helper(browser);
            _driver = helper.Driver;
        }


        [Test]
        public void HomePage_Title()
        {
            //_driver.Navigate().GoToUrl(helper.BaseUrl);
            _driver.Navigate().GoToUrl("http://localhost:24847");
            var pageSource = _driver.PageSource;

            Thread.Sleep(5000);
            string title= _driver.FindElement(By.CssSelector("#welcometext>header")).Text;


            Assert.AreEqual(title, "Joe's Coffee Store");
            helper.GetSessionId();
        }


        [Test]
        public void HomePage_Title1()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            string title = helper.Driver.FindElement(By.XPath(".//*[@id='headername']")).Text;
            Assert.AreEqual(title, "Joe's Coffee Store");
            helper.GetSessionId();
        }


        [Test]
        public void HomePage_Title2()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            string title = helper.Driver.FindElement(By.XPath("//*[@id='headername']")).Text;
            Assert.AreEqual(title, "Joe's Coffee Store1");
            helper.GetSessionId();
        }


        [TearDown]
        public void Teardown()
        {

            Console.WriteLine("Teardown SessionId");
            //helper.GetSessionId();
            helper.Driver.Quit();
        }
    }
}
