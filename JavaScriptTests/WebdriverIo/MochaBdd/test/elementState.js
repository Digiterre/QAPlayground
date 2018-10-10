
describe('Element State Feature', function(){

    beforeEach(function (){
        browser.url('https://www.amazon.co.uk/');
    });

    it('IsVisible Test', function(){
        var isVisible = browser.isVisible('nav-shop');
        //expect(isVisible, "element exists").to.be.true();
    });

    it('IsExisting Test', function(){
        var hasVisible = browser.isExisting('nav-shop');
        //expect(hasVisible, "element is visible").to.be.true();
    });
});