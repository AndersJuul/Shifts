(function () {
    'use strict';

    function aboutController() {
        var vm = this;
        vm.food = 'pizza';
    }

    angular
        .module('app')
        .controller('AboutController', aboutController);

})();