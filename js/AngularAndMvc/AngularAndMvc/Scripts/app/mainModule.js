angular.module('sample', [
    'ngSanitize',
    'sample.ctrl.home',
    'sample.ctrl.list',
    'sample.ctrl.edit',
    'sample.service.news'
]).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/Home/List',
        controller: 'listCtrl'
    });

    $routeProvider.when('/create', {
        templateUrl: '/Home/Edit',
        controller: 'editCtrl'
    });

    $routeProvider.when('/edit/:id', {
        templateUrl: '/Home/Edit',
        controller: 'editCtrl'
    });

    $routeProvider.otherwise({ redirectTo: '/' });

    // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true);
}]);