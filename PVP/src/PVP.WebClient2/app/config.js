(function () {

    "use strict";

    function config($routeProvider) {
        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: 'app/home/home.view.html',
                controller: 'HomeController',
                controllerAs: 'vm'
            })

            // route for the about page
            .when('/users', {
                templateUrl: 'app/user/users.view.html',
                controller: 'UsersController',
                controllerAs: 'vm'
            })

            // route for the contact page
            .when('/user/:id', {
                templateUrl: 'app/user/user.view.html',
                controller: 'UserController',
                controllerAs: 'vm'
            });
    }

    angular.module('pvpdemo').config(config);
}());
