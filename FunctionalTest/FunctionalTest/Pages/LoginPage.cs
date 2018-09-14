using System;
using System.Configuration;
using FunctionalTest.TestSetup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FunctionalTest.Pages
{
    public class LogInPage : BasePage
    {
        private Uri _loginPageUri;
        public LogInPage(IWebDriver driver) : base(driver)
        {
            _loginPageUri = new Uri(ConfigurationManager.AppSettings["testUrl"]);
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(_loginPageUri);
            Driver.Manage().Window.Maximize();
        }
        //Elements
        [FindsBy(How = How.Id, Using = "ap_email")]
        private IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "nav-link-yourAccount")]
        private IWebElement SignIn { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement ContinueButton { get; set; }

        [FindsBy(How = How.Id, Using = "ap_password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        private IWebElement SignInButton { get; set; }


        internal void Login(Table table)
        {   
            SignIn.Click();
            dynamic values = table.CreateDynamicInstance();
            string email = values.userName.ToString();
            string password = values.password.ToString();
            Email.Click();
            Email.SendKeys(email);
            ContinueButton.Click();
            Password.Click();
            Password.SendKeys(password);
            ClickLogin();
        }

        internal  void LoginWithUnknownEmail(Table table)
        {
            SignIn.Click();
            dynamic values = table.CreateDynamicInstance();
            string email = values.userName.ToString();
            //string password = values.password.ToString();
            Email.Click();
            Email.SendKeys(email);
            ContinueButton.Click();

        }

        public ShopPage ClickLogin()
        {   
            SignInButton.Click();
            return new ShopPage(DriverSingleton.Driver);
        }


    }
}
