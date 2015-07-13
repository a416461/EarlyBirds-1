(function () {
    'use strict';
    angular
        .module('earlyBirdsApp')
        .directive('lvlDropTarget', lvlDropTarget);

    lvlDropTarget.$inject = ['gridEventHelper'];

    function lvlDropTarget(gridEventHelper) {
        let directive = {
            restrict: 'A',
            link: linkFunction
        };
        return directive;
        
        function linkFunction(scope, el, attrs, controller) {
            el.on("dragover", function (e) {
                if (e.preventDefault) {
                    e.preventDefault();
                }
                return false;
            });
            el.on("dragenter", function (e) { });
            el.on("dragleave", function (e) {});
            el.on("drop", gridEventHelper.droppedUpon);
        }
    }
})();