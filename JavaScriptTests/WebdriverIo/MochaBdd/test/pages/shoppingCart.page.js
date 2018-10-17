class ShoppingCartPage{

    get productInBasketTitle() {return $("span.a-size-medium.sc-product-title.a-text-bold");}

    returnProductInBasketName(){
        return this.productInBasketTitle.getText();
    }

}
module.exports = new ShoppingCartPage();