#WebdriverIO is a test automation framework that allows you to run tests based on the Webdriver protocol and Appium automation technology. It provides support for your favorite BDD/TDD test framework and will run your tests locally or in the cloud using Sauce Labs, BrowserStack or TestingBot.

##Setup using WebdriverIO Test Runner (provides an easier way to manage configurations)


Using powershell cmd: 
Ensure you have installed node and npm
If on windows ensure you have installed Node.js tool (see): https://github.com/nodejs/node-gyp  

Create a project folder
Run: 'npm install'
Run: 'npm init'
Run: 'npm install --save-dev webdriverio selenium-standalone'
Run :'/.node_modules/.bin/wdio' - this will allow you config your test runner with options like:
environment to run (local), test framework (mocha), test location (your choice), services (selenium-standalone) - helps to start selenium server on test run, logging options, error screenshot setup etc.


##
To Test, create a simple javascript file in your test location. paste the code below:

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


to run your test in powershell run .\node_modules\.bin\wdio