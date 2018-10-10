
var chai  = require("chai");
var expect = chai.expect;

describe('Element State Feature', function(){

    beforeEach(function (){
        browser.url('https://www.amazon.co.uk/');
        browser.windowHandleMaximize();    
    });

    it('IsVisible Test', function(){
        var hasVisible = browser.isVisible('#nav-your-amazon');
        expect(hasVisible, "element is not visible").to.be.true;
    });

    it('IsExisting Test', function(){
        var hasVisible = browser.isVisible('#nav-your-amazon');
        expect(hasVisible, "element does not exist").to.be.true;
    });

    it('HasFocus Test', function(){
        var hasVisible = browser.hasFocus('#nav-your-amazon');
        expect(hasVisible, "element does not exist").to.be.false;
    });

    it('WaitFor Test', function(){
        //ToDo
    });

    it('WaitUntil Test', function(){
        //ToDo
    });
});