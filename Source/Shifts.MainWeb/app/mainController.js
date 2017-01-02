(function () {
    'use strict';

    function mainController() {
        var vm = this;
        vm.food = 'pizza';
    }

    angular
        .module('app')
        .controller('MainController', mainController);

})();