(function () {
    'use strict';

    function mainController($scope) {
        $scope.food = 'pizza';
    }

    angular
        .module('app')
        .controller('MainController', mainController);

})();