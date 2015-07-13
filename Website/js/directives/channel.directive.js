(function () {
    'use strict';

    angular
        .module('earlyBirdsApp')
        .directive('channel', channel);
    
    function channel() {
        var directive = {
            restrict: 'E',
            templateUrl: '/templates/directives/channel.html',
            replace: true
        };
        return directive;
    }
})();