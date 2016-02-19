(function () {
    "use strict";

    function UserController(UsersService) {
        var vm = this;
        vm.user = {};

        function init() {

            vm.user = UsersService.currentUser;
        }

        init();

    }

    angular.module('pvpdemo').controller('UserController', UserController);

    UserController.$inject = ['UsersService'];

}());