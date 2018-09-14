using OpenQA.Selenium;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace FunctionalTest.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            InitElements(Driver, this);
        }

    }
}
