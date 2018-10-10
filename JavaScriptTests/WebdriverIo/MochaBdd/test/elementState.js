
var chai  = require("chai");
var expect = chai.expect;

describe('Element State Feature', function(){

    beforeEach(function (){
        browser.url('https://www.amazon.co.uk/');
        browser.windowHandleMaximize();    
    });

    it('Search Test', function(){
        browser.clearElement("#twotabsearchtextbox").setValue("#twotabsearchtextbox","Mens Clothing");
        browser.element("//*[@id='nav-search']/form/div[2]/div/input").click();
        var pagetitle = browser.getText("//*[@id='merchandised-content']/div[1]/div[1]/div[1]/h1");
        console.log(pagetitle);
        expect(pagetitle).to.match("Men's Clothing");
    });

    it('Select Shop Department', function(){
        browser.element("div#nav-shop").click();



    });

});