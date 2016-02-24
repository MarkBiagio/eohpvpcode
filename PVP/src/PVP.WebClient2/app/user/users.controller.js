(function () {
    "use strict";

    function UsersController(UsersFactory, $location, userInfo) {
        var vm = this;

        function viewUser(user) {
            $location.path('/user/' + user.id);
        }

        function init() {
            vm.users = UsersFactory.getUsers();
        }

        init();

        vm.onUserClick = viewUser;
    }

    angular.module('pvpdemo').controller('UsersController', UsersController);

    UsersController.$inject = ['UsersFactory', '$location'];

}());