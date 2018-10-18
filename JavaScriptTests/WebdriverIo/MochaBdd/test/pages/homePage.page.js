class HomePage{

    get searchTextBox(){ return $("#twotabsearchtextbox");}
    get searchButton(){return $("//*[@id='nav-search']/form/div[2]/div/input");}
    get searchedPageTitle(){return $("//*[@id='merchandised-content']/div[1]/div[1]/div[1]/h1");}
    get allDepartmentsTab(){return $("a#nav-link-shopall");}
    get sportsNutritionItemsLink(){return $("//*[@id='shopAllLinks']/tbody/tr/td[3]/div[5]/ul/li[11]/a");}
    get nutritionPageTitle(){return $("//*[@id='merchandised-content']/div[1]/div[1]/div/h1");}
    get loginToAccountTab(){return $ ("#nav-link-yourAccount");}
    get ContinueBtn(){return $("span#continue");}
    get missingEmailAlertMsg(){return $("//*[@id='auth-email-missing-alert']/div/div");}
    get FirstReturnedProduct(){return $("li#result_0");}
    get SignInButton(){return $("//*[@id='signInSubmit']");}

    searchForItem(value){
        this.searchTextBox.setValue(value);
    }

    clickSearchButton(){
        this.searchButton.click();
    }

    returnSearchPageText(){
        return this.searchedPageTitle.getText();
    }

    clickShopAllDepartment(){
        this.allDepartmentsTab.click();       
    }

    goToSportsNutritionLink(){
        this.sportsNutritionItemsLink.scroll();
        this.sportsNutritionItemsLink.click();       
    }

    returnNutritionPageTitle(){
        return this.nutritionPageTitle.getText();
    }

    clickSignInButton(){
        this.loginToAccountTab.click();
    }

    clickContinueButton(){
        if(this.SignInButton.isVisible()){
            this.SignInButton.click();
        }
        else{
            this.ContinueBtn.click();
        }       
    }

    enterEmptyDetails(){
        this.clickSignInButton();
        this.clickContinueButton();
    }

    returnEmptyEmailAlert(){
        return this.missingEmailAlertMsg.getText();
    }   
}
module.exports = new HomePage();