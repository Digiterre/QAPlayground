class ItemPage{
    get AddToCartButton(){return $("input#add-to-cart-button");}
    get EditCartButton(){return $("a#hlb-view-cart-announce");}
    get SelectedProductTitle(){return $("span#productTitle");}


    returnSelectedProductTitle(){
        return this.SelectedProductTitle.getText();
    }

    clickAddToCartButton(){
        this.AddToCartButton.click();
    }

    clickEditCartButton()
    {
        this.EditCartButton.click();
    }
}
module.exports = new ItemPage();