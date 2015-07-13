(function () {
    'use strict';
    angular
        .module('earlyBirdsApp')
        .directive('lvlDraggable', lvlDraggable);

    lvlDraggable.$inject = ['gridEventHelper'];

    function lvlDraggable(gridEventHelper) {
        let directive = {
            restrict: 'A',
            link: linkFunction
        };
        return directive;

        function linkFunction(scope, el, attrs, controller) {
            angular.element(el).attr("draggable", "true");
            el.on("dragstart", gridEventHelper.drag);
            el.on("dragend", gridEventHelper.drop);
        }
    }
})();
