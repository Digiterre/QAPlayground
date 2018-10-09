
describe('Demo Feature', function(){

    it('my first demo test', function(){
        browser.url('./');
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