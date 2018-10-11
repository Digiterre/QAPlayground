

describe('Demo Feature', function(){

    beforeEach(function(){
        browser.url('./');
    });
    
    it('my first demo test', function(){      
        var title = browser.getTitle();
        console.log('Title is: ' + title);
        browser.setValue('#search_form_input_homepage','Webdriverio');
        browser.click('#search_button_homepage');
        var theTile = browser.getTitle();
        console.log('Title is :' + theTile);
        var theUrl = browser.getUrl();
        console.log('Url is:' + theUrl);
    });   
});