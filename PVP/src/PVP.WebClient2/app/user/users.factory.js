(function () {
    "use strict";

    var baseUrl = "/api";
   
    function UsersFactory($q, $http) {
        
        var cachedUsers = [];
        
        var getUsers = function () {
            if (cachedUsers.length != 0) return $q.when(cachedUsers);

            return $http.get(baseUrl + '/users').then(function (response) {
                return response.data;
            });
        };
        
        var getUser = function (id) {
            return getUsers().then(function (users) {
                for (var user of users) {
                    if (user.id == id) return user;
                }
            });
        };

        return {
            getUsers: getUsers,
            getUser: getUser
        };
    }

    angular.module('pvpdemo').factory('UsersFactory', UsersFactory);

    UsersFactory.$inject = ['$q', '$http'];

}());