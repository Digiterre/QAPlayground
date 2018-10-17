var homePage = require('./pages/homePage.page');
var shoppingCartPage = require('./pages/shoppingCart.page');
var itemPage = require('./pages/itemPage.page');
var resultsPage = require('./pages/searchResults.page');
describe('Element State Feature', function(){

    beforeEach(function (){
        browser.url('./');
        browser.windowHandleMaximize();    
    });

    it('Search For A Product', function(){     
        homePage.searchForItem('Mens Clothing');
        homePage.clickSearchButton();
        var pagetitle = homePage.returnSearchPageText();
        console.log(pagetitle);
        expect(pagetitle).to.match(/Men's Clothing/);
    });

    it('Scroll On Page And Click On An Element', function(){
        homePage.clickShopAllDepartment();
        homePage.goToSportsNutritionLink();
        var title = homePage.returnNutritionPageTitle();
        console.log(title);
        expect(title).to.match(/Sports Nutrition/);       
    });

    it("Check Empty Details Alert", function(){
        homePage.enterEmptyDetails();
        var alertMsg = homePage.returnEmptyEmailAlert();
        console.log(alertMsg);
        expect(alertMsg).to.contain("Enter your e-mail address or mobile phone number");
    });

    it("Add To Shopping Cart", function(){
        homePage.searchForItem('Converse');
        homePage.clickSearchButton();
        resultsPage.selectFirstResult();
        var selectedProduct = itemPage.returnSelectedProductTitle();
        console.log(selectedProduct);
        expect(selectedProduct).to.contain("Converse");
        itemPage.clickAddToCartButton();
        itemPage.clickEditCartButton();
        var nameOfSelectedItem = shoppingCartPage.returnProductInBasketName();
        console.log(nameOfSelectedItem);
        expect(nameOfSelectedItem).to.contain("Converse");       

    });

});