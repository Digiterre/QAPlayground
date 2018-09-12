using System;
using FunctionalTest.Pages;
using FunctionalTest.TestSetup;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestContext = FunctionalTest.TestSetup.TestContext;

namespace FunctionalTest.Steps
{
    [Binding]
    public class ShopCartSteps
    {
        private TestContext _testContext;

        public ShopCartSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Given(@"I log in with the following details:")]
        public void GivenILogInWithTheFollowingDetails(Table table)
        {
            LoginToSiteWithUnknownUser(table);
        }

        [Then(@"I should land on the shoppingPage")]
        public void ThenIShouldLandOnTheShoppingPage()
        {
            _testContext.CurrentPage = new ShopPage(DriverSingleton.Driver);
            var shoppingPageText = _testContext.GetCurrentPageAs<ShopPage>().GetUserAmazonText();
            Assert.True(shoppingPageText.Contains("Eyong's Amazon"), "The User Greeting is not correct");
        }

        [Then(@"I should be prompted with incorrect login message:")]
        public void ThenIShouldBePromptedWithIncorrectLoginMessage(Table table)
        {
            _testContext.CurrentPage = new ShopPage(DriverSingleton.Driver);
            dynamic values = table.CreateDynamicInstance();
            string message = values.message.ToString();
            var loginErrorMessage = _testContext.GetCurrentPageAs<ShopPage>().GetErrorMessage();
            Assert.True(loginErrorMessage.Contains(message), "Incorrect Error Message");
        }


        [When(@"I search for shoes by the following criteria:")]
        public void WhenISearchForShoesByTheFollowingCriteria(Table table)
        {
            _testContext.CurrentPage = new ShopPage(DriverSingleton.Driver);
            _testContext.GetCurrentPageAs<ShopPage>().SearchForItemsByCriteria(table);
        }

        [Then(@"I should be returned products with the searched criteria")]
        public void ThenIShouldBeReturnedProductsWithTheSearchedCriteria()
        {
            string searchedContent = _testContext.GetCurrentPageAs<ShopPage>().ReturnMerchandisedContentName();
            Assert.True(searchedContent.Equals("Men's Clothing"), "The returned searches do not match the queried subgroup of Items");
        }

        [Given(@"I have (.*) products in the basket")]
        public void GivenIHaveProductsInTheBasket(string quantity)
        {

            _testContext.CurrentPage = new ShopPage(DriverSingleton.Driver);
            _testContext.GetCurrentPageAs<ShopPage>().AddRandomItems(quantity);
            _testContext.GetCurrentPageAs<ShopPage>().ClickAddToBasketBtn();
        }
        [Given(@"I am on the ShoppingPage")]
        public void GivenIAmOnTheShoppingPage()
        {
            _testContext.CurrentPage = new LogInPage(DriverSingleton.Driver);
            _testContext.GetCurrentPageAs<LogInPage>().Open();
        }


        [When(@"I change the quantity of items in the basket to (.*)")]
        public void WhenIChangeTheQuantityOfItemsInTheBasketTo(string quantity)
        {
            _testContext.GetCurrentPageAs<ShopPage>().ClickEditButton();
            _testContext.GetCurrentPageAs<ShopPage>().ReduceBasketQuantity(quantity);
        }

        [Then(@"the number of items should be updated correctly to (.*)")]
        public void ThenTheNumberOfItemsShouldBeUpdatedCorrectlyTo(string quantity)
        {
            var subtotal = _testContext.GetCurrentPageAs<ShopPage>().GetDisplayedBasketQty();
            var text = "Subtotal (" + quantity + " item)";
            Assert.That(subtotal.Contains(text));
        }

        public void LoginToSite(Table table)
        {
            _testContext.CurrentPage = new LogInPage(DriverSingleton.Driver);
            _testContext.GetCurrentPageAs<LogInPage>().Open();
            _testContext.GetCurrentPageAs<LogInPage>().Login(table);
        }

        public void LoginToSiteWithUnknownUser(Table table)
        {
            _testContext.CurrentPage = new LogInPage(DriverSingleton.Driver);
            _testContext.GetCurrentPageAs<LogInPage>().Open();
            _testContext.GetCurrentPageAs<LogInPage>().LoginWithUnknownEmail(table);
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            _testContext.GetCurrentPageAs<ShopPage>().ClickProceedToCheckout();
        }

        [Then(@"I should see be asked to provide my login information")]
        public void ThenIShouldSeeBeAskedToProvideMyLoginInformation()
        {
            bool authenticateUserRequest = _testContext.GetCurrentPageAs<ShopPage>().LoginFormDisplayed();
            Assert.True(authenticateUserRequest, "User was not prompted for login");
        }

        [Given(@"I sign up to site with valid details:")]
        public void GivenISignUpToSiteWithValidDetails(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I return to the site and login with the created account:")]
        public void WhenIReturnToTheSiteAndLoginWithTheCreatedAccount(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should successfully be logged into the site")]
        public void ThenIShouldSuccessfullyBeLoggedIntoTheSite()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
