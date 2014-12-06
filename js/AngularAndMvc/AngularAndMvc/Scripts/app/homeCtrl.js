angular.module('sample.ctrl.home', [])
    .controller('homeCtrl', ['$scope', '$location', function ($scope, $location) {        
        $location.path('/');

    }]);