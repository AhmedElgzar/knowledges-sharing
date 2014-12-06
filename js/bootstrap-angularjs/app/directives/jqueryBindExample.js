shoppingCart.directive('jqueryBindExample',function(){
    return{
        restrict: 'A', //E means elemnts, a-attribut, C- class
        link: function(scope, element, attrs){
            $(element).addClass('class-from-jquery');
        }
    }
});