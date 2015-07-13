(function () {
    'use strict';

    let app = angular.module('earlyBirdsApp');

    app.factory('gridEventHelper', function () {
        let dragListeners = [];
        let dropListeners = [];
        let droppedUponListeners = [];

        return {
            drag: function (event) {
                dragListeners.forEach(function (cb) {
                    cb(event);
                });
            },

            drop: function (event) {
                dropListeners.forEach(function (cb) {
                    cb(event);
                });
            },

            droppedUpon: function (event) {
                droppedUponListeners.forEach(function (cb) {
                    cb(event);
                });
            },

            registerDrag: function (callback) {
                dragListeners.push(callback);
            },

            registerDrop: function (callback) {
                dropListeners.push(callback);
            },

            registerDroppedUpon: function (callback) {
                droppedUponListeners.push(callback);
            }
        }
    });

})();