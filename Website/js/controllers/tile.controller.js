(function () {
    'use strict';

    let app = angular.module('earlyBirdsApp');

    app.controller('TileController',
    function TileController($scope, serverCommunication) {


        $scope.submitResponse = function submitResponse(id, response) {
            let res = {
                Response: response
            }
            serverCommunication.editTicketResponse(id, res).then(function (ticket) {
                updateTile();
            }, function (statusCode) { console.log(statusCode); });
        }

        $scope.deleteTicket = function deleteTicket(id) {
            serverCommunication.deleteTicket(id).then(function (ticket) {
                updateTile();
            }, function (statusCode) { console.log(statusCode); });
        }

        $scope.submitMessage = function submitMessage() {
            let mes = {
                Text: $scope.chatText,
                UserId: 1,
                ChatLogId: $scope.chan.chatLog.id
            };

            serverCommunication.sendMessage(mes).then(function () {
                updateTile();
            }, function (statusCode) { console.log(statusCode); });
        }

        $scope.openChannel = function openChannel() {

        }

        function updateTile() {
            switch ($scope.title) {
                case 'Users':
                    serverCommunication.getUsers().then(function (users) {
                        $scope.users = users;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                case 'Channels':
                    serverCommunication.getChannels().then(function (channels) {
                        $scope.channels = channels;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                case 'User Channels':
                    serverCommunication.getUserChannels().then(function (uchannels) {
                        $scope.uchannels = uchannels;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
                default:
                    serverCommunication.getChannel($scope.title).then(function (chan) {
                        $scope.chan = chan;
                        $scope.tickets = chan.tickets;
                    }, function (statusCode) { console.log(statusCode); });
                    break;
            }
        }

        $scope.hideShowChat = function hideShowChat() {
            if ($scope.title === 'Channels' || $scope.title === 'Users' || $scope.title === 'User Channels') {
                return true;
            } else {
                return false;
            }
        }
    });
})();