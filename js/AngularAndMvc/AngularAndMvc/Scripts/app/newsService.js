angular.module("sample.service.news", []).factory('newsService', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http({ method: 'GET', url: '/api/ArticleService' });
        },
        getById: function (id) {
            return $http({ method: 'GET', url: '/api/ArticleService/'+id });
        },
        create: function (news) {
            return $http({ method: 'POST', url: '/api/ArticleService/', data: news });
        },
        update: function (news) {
            return $http({ method: 'PUT', url: '/api/ArticleService/', data: news });
        },
        remove: function (id) {
            return $http({ method: 'DELETE', url: '/api/ArticleService/' + id });
        }
    }
}]);