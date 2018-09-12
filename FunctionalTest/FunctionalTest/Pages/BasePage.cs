using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FunctionalTest.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }


        public string Title()
        {
            return Driver.Title;
        }
        public string Url()
        {
            return Driver.Url;
        }


    }
}
