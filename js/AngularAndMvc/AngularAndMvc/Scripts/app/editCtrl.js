angular.module('sample.ctrl.edit', [])
    .controller('editCtrl', ['$scope', '$routeParams', '$location', 'newsService', function ($scope, $routeParams, $location, newsService) {        
        $scope.Back = function () {
            $location.path('/');
        }        
        $scope.news = { Name: '', Content: '' };
        var isNew = angular.isUndefined($routeParams.id);
        if(!isNew) {
            newsService.getById($routeParams.id).success(function (data, status, headers, config) {
                $scope.news = data;
            });
        }        

        $scope.save = function (news) {            
            if (news.$valid) {
                if (isNew) {
                    newsService.create($scope.news).success(function (data, status, headers, config) {
                        $location.path('/');
                    }).error(function (data, status, headers, config) {
                        alert('Create operation failed. [HTTP-' + status + ']');
                    });
                }
                else {
                    newsService.update($scope.news).success(function (data, status, headers, config) {
                        $location.path('/');
                    }).error(function (data, status, headers, config) {
                        alert('Update operation failed. [HTTP-' + status + ']');
                    });
                }
            }
        }

    }]);