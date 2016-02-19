(function () {
    "use strict";

    function UsersFactory($q, $http) {
        
        var getUsers = function () {
            var deferred = $q.defer();

            var getDataComplete = function (response) {
                deferred.resolve(response.data);
            };

            var getDataError = function (err, status) {
                status = status;

                deferred.reject(err);
            };

            $http.get(baseUrl + moduleUrl + '/api/clients').then(getDataComplete, getDataError);

            return deferred.promise;
        };

        return {
            getUsers: getUsers
        };
    }

    angular.module('pvpdemo').factory('UsersFactory', UsersFactory);

    UsersFactory.$inject = ['$q', '$http'];

}());