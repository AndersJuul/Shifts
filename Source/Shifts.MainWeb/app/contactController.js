(function () {
    'use strict';

    function contactController($scope) {
        $scope.food = 'contact-is';
    }

    angular
        .module('app')
        .controller('ContactController', contactController);

})();