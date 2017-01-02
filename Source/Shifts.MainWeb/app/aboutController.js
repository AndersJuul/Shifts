(function () {
    'use strict';

    function aboutController($scope) {
        $scope.food = 'avout-is';
    }

    angular
        .module('app')
        .controller('AboutController', aboutController);

})();