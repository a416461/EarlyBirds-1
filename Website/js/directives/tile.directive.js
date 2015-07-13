(function () {
    'use strict';
    angular
        .module('earlyBirdsApp')
        .directive('tile', tile);

    tile.$inject = ['serverCommunication'];

    function tile(serverCommunication) {
        
        let directive = {
            restrict: 'E',
            replace: true,
            templateUrl: '../templates/directives/tile.html',
            controller: 'TileController',
            link: linkFunction,
            scope:
            {
                click: '=click',
                close: '=close'
            }
        }
        return directive;

        function linkFunction(scope, element, attrs, controller) {
            scope.title = attrs.title;
            switch (scope.title) {
                case 'Users':
                    serverCommunication.getUsers().then(function (users) {
                        scope.users = users;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                case 'Channels':
                    serverCommunication.getChannels().then(function (channels) {
                        scope.channels = channels;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                case 'User Channels':
                    serverCommunication.getUserChannels().then(function (uchannels) {
                        scope.uchannels = uchannels;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                default:
                    serverCommunication.getChannel(scope.title).then(function (chan) {
                        scope.chan = chan;
                        scope.tickets = chan.tickets;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
            }
        }
    }
})();