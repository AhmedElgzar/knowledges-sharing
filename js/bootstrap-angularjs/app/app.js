var shoppingCart = angular.module('shoppingCart',['ngRoute']);
shoppingCart.config(['$routeProvider', function($routeProvider){
    $routeProvider.when('/',{
       templateUrl: 'app/views/home.html',
       controller: 'productController'
    });
    $routeProvider.when('/product/:id',{
       templateUrl: 'app/views/details.html',
       controller: 'detailsController'
    });

    $routeProvider.when('/cart',{
        templateUrl: 'app/views/cart.html',
        controller: 'cartController'
    });
    $routeProvider.otherwise({ redirectTo: '/' });
}]);