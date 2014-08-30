shoppingCart.directive('cartTemplate',function(){
    return {
        template: '<a href="#/cart"><span class="glyphicon glyphicon-shopping-cart"></span>{{count}} items - ${{total}}</a>'
    }
})