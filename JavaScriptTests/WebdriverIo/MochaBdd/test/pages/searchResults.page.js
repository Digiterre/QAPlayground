class SearchResultsPage{

    get FirstReturnedProduct(){return $("li#result_0");}
    get SelectedProductTitle(){return $("span#productTitle");}


    selectFirstResult(){
        this.FirstReturnedProduct.click();
    }

    
}
module.exports = new SearchResultsPage();