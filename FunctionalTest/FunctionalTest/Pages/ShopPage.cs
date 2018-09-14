using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FunctionalTest.Pages
{
    public class ShopPage : BasePage
    {
        
        public ShopPage(IWebDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.Id, Using = "nav-your-amazon")]
        private IWebElement UserGreeting { get; set; }

        [FindsBy(How = How.Id, Using = "searchDropdownBox")]
        private IWebElement CategoryDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        private IWebElement SearchBox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#nav-search > form > div.nav-right > div > input")]
        private IWebElement SubmitSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.bxw-pageheader__title > div.bxw-pageheader__title__text > h1")]
        private IWebElement MerchandisedContentTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='quantity']/option")]
        private IWebElement QuantityDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "hlb-view-cart")]
        private IWebElement EditBasketButton { get; set; }

        [FindsBy(How = How.Id, Using = "hlb-ptc-btn")]
        public IWebElement ProceedToCheckout { get; set; }

        [FindsBy(How = How.Id, Using = "a-autoid-0-announce")]
        private IWebElement BasketQtyDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span#sc-subtotal-label-activecart")]
        private IWebElement DisplayedBasketQuantity { get; set; }

        [FindsBy(How = How.Id, Using = "native_dropdown_selected_size_name")]
        private IWebElement SelectSizeDropdown { get; set; }


        public string GetUserAmazonText()
        {
            var userGreeting = UserGreeting.Text;
            return userGreeting;
        }

        public void SearchForItemsByCriteria(Table table)
        {
            dynamic criteria = table.CreateDynamicInstance();
            string category = criteria.category.ToString();
            string type = criteria.Type.ToString();
            string Men = criteria.subGroup.ToString();
            CategoryDropdown.Click();
            var options = Driver.FindElements(By.CssSelector("#searchDropdownBox > option"));
            foreach (IWebElement opt in options)
            {
                if (opt.Text.Contains(category))
                {
                    opt.Click();
                    break;
                }
                
            }

            SearchBox.SendKeys(type);
            SubmitSearch.Click();

            var leftNavBroserOptions = Driver.FindElements(By.CssSelector("div.left_nav.browseBox > ul >li"));
            foreach (IWebElement navOption in leftNavBroserOptions)
            {
                if (navOption.Text.Contains(Men))
                {
                    navOption.Click();
                    break;
                }
            }

        }

        internal void ClickEditButton()
        {
            EditBasketButton.Click();
        }

        public string ReturnMerchandisedContentName()
        {
            string merhandisedName = MerchandisedContentTitle.Text;
            return merhandisedName;
        }

        public void AddRandomItems(string quantity)
        {
            SearchBox.SendKeys("Henleys Mens Milo Canvas Pumps");
            SubmitSearch.Click();

            var results = Driver.FindElements(By.CssSelector("div.a-fixed-left-grid-col.a-col-left"));
            var firstResult = results[0];
            firstResult.Click();
            SelectSizeDropdown.Click();
            Thread.Sleep(2000);
            var sizes = Driver.FindElements(By.XPath("//*[@id='native_dropdown_selected_size_name']/option"));
            var firstAvailableSize = sizes[2];
            firstAvailableSize.Click();
            Thread.Sleep(2000);
            QuantityDropdown.Click();
            var quantityDropdown = Driver.FindElements(By.XPath("//*[@id='quantity']/option"));
            foreach (IWebElement option in quantityDropdown)
            {
                if (option.Text.Contains(quantity))
                {
                    option.Click();
                    break;
                }
            }

        }

        public void ReduceBasketQuantity(string quantity)
        {
            BasketQtyDropdown.Click();
            var quantityOptions = Driver.FindElements(By.CssSelector("li.a-dropdown-item.quantity-option"));
            foreach (IWebElement option in quantityOptions)
            {
                if (option.Text.Equals(quantity))
                {
                    option.Click();
                    break;
                }
            }

        }

        public string GetDisplayedBasketQty()
        {
            Thread.Sleep(2000);
            string basketQuantity = DisplayedBasketQuantity.Text;
            return basketQuantity;
        }

        public void ClickAddToBasketBtn()
        {   
            //workaround stale element issue.
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    string xpath = "//span[@id='submit.add-to-cart']";
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    Driver.FindElement(By.XPath(xpath)).Click();
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
        }

        public string GetErrorMessage()
        {
            string message = Driver.FindElement(By.CssSelector("#auth-error-message-box > div >div >ul>li>span")).Text;
            return message;
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            
        }

        public bool LoginFormDisplayed()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var loginForm =  Driver.FindElement(By.Name("signIn")).Displayed;
            return loginForm;
        }
    }
}
