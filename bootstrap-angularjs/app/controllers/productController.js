shoppingCart.controller('productController',['$scope','productService', function($scope, productService){
    productService.getAll().success(function (data, status, headers, config) {
        $scope.products = data;
    });
}]);