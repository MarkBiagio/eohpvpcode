(function () {
    "use strict";

    function UserController(UsersFactory, $routeParams) {
        var vm = this;

        function init() {
            vm.user = UsersFactory.getUser($routeParams.id);
        }

        init();
    }

    angular.module('pvpdemo').controller('UserController', UserController);

    UserController.$inject = ['UsersFactory', '$routeParams'];

}());