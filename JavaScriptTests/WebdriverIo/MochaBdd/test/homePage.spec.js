
var chai  = require("chai");
var expect = chai.expect;

describe('Element State Feature', function(){

    beforeEach(function (){
        browser.url('./');
        browser.windowHandleMaximize();    
    });

    it('Search For A Product', function(){
        browser.clearElement("#twotabsearchtextbox").setValue("#twotabsearchtextbox","Mens Clothing");
        browser.pause(500);
        browser.element("//*[@id='nav-search']/form/div[2]/div/input").click();
        var pagetitle = browser.getText("//*[@id='merchandised-content']/div[1]/div[1]/div[1]/h1");
        console.log(pagetitle);
        expect(pagetitle).to.match(/Men's Clothing/);
    });

    it('Scroll On Page And Click On An Elememt', function(){
        browser.element("a#nav-link-shopall").click();
        browser.scroll("//*[@id='shopAllLinks']/tbody/tr/td[3]/div[5]/ul/li[11]/a",103.88 ,17);
        browser.element("//*[@id='shopAllLinks']/tbody/tr/td[3]/div[5]/ul/li[11]/a").click();
        var pageSubtitle = browser.getText("//*[@id='merchandised-content']/div[1]/div[1]/div/h1");
        console.log(pageSubtitle);
        expect(pageSubtitle).to.match(/Sports Nutrition/);
    });

    it("Check Empty Details Alert", function(){
        browser.element("a#nav-link-yourAccount").click();
        browser.pause(500);
        browser.element("span#continue").click();
        var message = browser.element("//*[@id='auth-email-missing-alert']/div/div").getText();
        expect(message).to.match(/Enter your e-mail address or mobile phone number/);
    });

    it("Add To Shopping Cart", function(){
        browser.clearElement("#twotabsearchtextbox").setValue("#twotabsearchtextbox","converse");
        browser.element("//*[@id='nav-search']/form/div[2]/div/input").click();
        browser.element("li#result_0").click();
        var selectedProduct = browser.element("span#productTitle").getText();
        expect(selectedProduct).to.contain("Converse");
        browser.element("input#add-to-cart-button").click();
        browser.element("a#hlb-view-cart-announce").click();
        var inbasket = browser.element("span.a-size-medium.sc-product-title.a-text-bold").getText();
        expect(inbasket).to.contain("Converse");
    });

});