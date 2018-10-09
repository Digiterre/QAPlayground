
describe('Demo Feature', function(){

    it('my first demo test', function(){

        return browser
        .url('./')
        .getTitle().then(function(title){
            console.log('Title is: ' + title);
        })
        .setValue('#search_form_input_homepage','Webdriverio')
        .click('#search_button_homepage')
        .getTitle().then(function(title){
            console.log('Title is :' + title);
        })
        .getUrl().then(function(url){
            console.log('Url is:' + url);
        });

    });
    
});
