shoppingCart.controller('detailsController',['$scope', '$rootScope', '$routeParams', 'productService', function($scope,$rootScope,$routeParams,productService){
    var id = $routeParams.id;
    productService.getById(id).success(function(data, status, headers, config){
       $scope.product =  data;
       $scope.currentImage = $scope.product.images[0];
    });

    $scope.changePicture = function(img){
        $scope.currentImage = img;
    }

    $scope.addToCart = function(){
        var items = localStorage.getItem('cart');
        if (!items){
            items = "[]";
        }
        items = angular.fromJson(items);
        items.push($scope.product);
        //localStorage.setItem('cart', angular.toJson(items));
        $rootScope.cart = items;
    }
}]);