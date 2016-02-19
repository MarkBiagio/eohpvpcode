(function () {
    "use strict";

    function HomeController() {
        var vm = this;
        vm.title = "";

        function init() {
            vm.title = "welcome to the demo";
        }

        init();

    }

    angular.module('pvpdemo').controller('HomeController', HomeController);

    //IndexController.$inject = [];

}());