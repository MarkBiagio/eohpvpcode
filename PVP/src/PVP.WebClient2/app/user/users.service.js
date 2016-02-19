﻿(function () {
    "use strict";

    function UsersService() {
        var vm = this;

        vm.users = [];
        vm.currentUser = {};

        function getUsers() {
            if (vm.users.length === 0) {
                vm.users.push({ UserId: 1, LoginName: 'm@b.co.za', Name: 'abc', IsActive: true, Roles: [{ RoleId: 1, Description: 'User' }, { RoleId: 2, Description: 'Administrator' }] });
                vm.users.push({ UserId: 2, LoginName: 'z@b.co.za', Name: 'xyz', IsActive: false, Roles: [{ RoleId: 2, Description: 'Administrator' }] });
            }
        }

        function setCurrentUser(user) {
            vm.currentUser = user;
        }

        //public
        vm.getUsers = getUsers;
        vm.setUser = setCurrentUser;

    }

    angular.module('pvpdemo').service('UsersService', UsersService);

    //IndexController.$inject = [];

}());