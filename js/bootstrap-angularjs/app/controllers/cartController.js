shoppingCart.controller('cartController',['$scope','$rootScope', function($scope,$rootScope){
    var getItems = function(){
        var items = localStorage.getItem('cart');
        if (!items){
            items = "[]";
        }
        return items;
    }

    $rootScope.cart = angular.fromJson(getItems());

    var calcSum = function(){
        var sum = 0;
        for (var i=0; i<$rootScope.cart.length; i++){
            sum+=$rootScope.cart[i].price;
        }
        $scope.total = sum;
    }
    calcSum();

    $scope.remove = function(index){
        //copy by value
        var items = $rootScope.cart.slice(0);
        items.splice(index, 1);
        $rootScope.cart = items;
        calcSum();
        //localStorage.setItem('cart', angular.toJson($scope.items));
    }
}]);