(function () {
    "use strict";

    function UsersController(UsersService, $location) {
        var vm = this;

        function viewUser(user) {
            UsersService.setUser(user);
            $location.path('/user');
        }

        function init() {
            vm.users = UsersService.users;
            UsersService.getUsers();
        }

        init();

        vm.onUserClick = viewUser;
    }

    angular.module('pvpdemo').controller('UsersController', UsersController);

    UsersController.$inject = ['UsersService', '$location'];

}());