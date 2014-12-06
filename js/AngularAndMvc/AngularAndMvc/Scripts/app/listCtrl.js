angular.module('sample.ctrl.list', [])
    .controller('listCtrl', ['$scope', '$location', 'newsService', function ($scope, $location, newsService) {
        $scope.news = [];        
        newsService.getAll().success(function (data, status, headers, config) {            
            $scope.news = data;
        });

        $scope.editNews = function (id) {            
            $location.path('/edit/' + id);
        };
        $scope.createNews = function () {
            $location.path('/create');
        };

        $scope.deleteNews = function (id) {            
            for (var i = 0; i < $scope.news.length; i++) {
                if ($scope.news[i].ID && $scope.news[i].ID == id) {
                    $scope.news.splice(i, 1);                    
                    break;
                }
            }
            newsService
                .remove(id)
                .success(function (data, status, headers, config) {
                    //$location.path('/');                    
                })
                .error(function (data, status, headers, config) {
                    alert('Delete operation failed. [HTTP-' + status + ']');
                });            
        };

    }]);