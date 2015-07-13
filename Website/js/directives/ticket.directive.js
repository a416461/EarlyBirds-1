(function () {
    'use strict';
    angular
        .module('earlyBirdsApp')
        .directive('ticket', ticket);

    ticket.$inject = [];

    function ticket() {
        return {
            restrict: 'E',
            templateUrl: '../templates/directives/ticket.html',
            replace: true
        }
    }
})();