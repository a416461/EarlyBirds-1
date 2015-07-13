(function () {
    'use strict';

    angular
        .module('earlyBirdsApp')
        .factory('serverCommunication', serverCommunication);
    
    serverCommunication.$inject = ['$http'];

    function serverCommunication($http) {
        let baseUrl = 'http://localhost:2001/';

        var service = {
            getUserInfo: getUserInfo,
            getUsers: getUsers,
            getChannel: getChannel,
            getUserChannels: getUserChannels,
            getChannels: getChannels,
            sendMessage: sendMessage,
            editTicketResponse: editTicketResponse,
            deleteTicket: deleteTicket
        };
        return service;
        
        function getUserInfo() {
            return httpRequest('users/1');
        }

        function getUsers() {
            return httpRequest('users');
        }

        function getChannel(title) {
            return httpRequest('channels/' + title);
        }

        function getUserChannels() {
            return httpRequest('users/1/channels');
        }

        function getChannels() {
            return httpRequest('channels');
        }

        function sendMessage(message) {
            console.log("Logging " + message.Text + " " + message.UserId + " " +message.ChatLogId);
            return httpPost('messages', message);
        }

        function editTicketResponse(ticketId, response) {
            return httpPut('tickets/' + ticketId, response);
        }

        function deleteTicket(id) {
            return httpDelete('tickets/' + id);
        }

        function httpRequest(requestString) {
            return $http
                .get(baseUrl + requestString)
                .then(function(response) {
                    return response.data;
                });
        }

        function httpPut(putString, object) {
            return $http
                .put(baseUrl + putString, object)
                .then(function (response) {
                    return response.data;
                });
        }

        function httpPost(postString, object) {
            return $http
                .post(baseUrl + postString, object)
                .then(function (response) {
                    return response.data;
                });
        }

        function httpDelete(deleteString) {
            return $http
                .delete(baseUrl + deleteString)
                .then(function (response) {
                    return response.data;
                })
        }
    }
})();
