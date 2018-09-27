import BasePage from './BasePage'

class HomePage extends BasePage {

    /*
    element definitions
    */
   get HomePageTitle(){ return browser.element('//*[@id="nav-logo"]/a[1]/span[1]');}


    /*
    Homepage functions
    */
    Open(){
        super.open('');
        browser.pause(1000);
    }

    getPageTitle(){
        return this.HomePageTitle.getText();
    }
}

export default new HomePage()