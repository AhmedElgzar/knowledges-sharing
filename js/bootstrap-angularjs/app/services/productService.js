shoppingCart.factory('productService',function($http){
    return {
        getAll: function(){
            return $http({"method": "GET", "url": "app/data/data.json"});
        },
        getById: function(id){
            return $http({"method": "GET", "url": "app/data/data"+id+".json"});
        }
    }
});
