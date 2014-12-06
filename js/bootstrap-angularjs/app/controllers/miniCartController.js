shoppingCart.controller('miniCartController',['$scope','$rootScope',function($scope,$rootScope){
    $scope.count = 0;
    $scope.total = 0;
    $scope.calculate = function(){
        var items = localStorage.getItem('cart');
        if (!items){
            items = "[]";
        }
        items = angular.fromJson(items);
        $scope.count = items.length;
        var sum = 0;
        for (var i=0; i<items.length; i++){
            sum+=items[i].price;
        }
        $scope.total = sum;
    }

    $scope.calculate();
    $rootScope.$watch('cart',function(newCart, oldCart){
        if(newCart){
            localStorage.setItem('cart', angular.toJson(newCart));
            $scope.calculate();
        }
    });
}]);