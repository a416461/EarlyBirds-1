(function () {
    'use strict';

    let app = angular.module('earlyBirdsApp');

    app.directive('collapsible', function () {
        return {
            restrict: 'E',
            template: '<div><h4 class="well-title" ng-click="toggleVisibility()">{{title}}</h4><div ng-show="visible" ng-transclude></div>',
            replace: true,
            controller: function ($scope) {
                $scope.visible = false;

                $scope.toggleVisibility = function () {
                    $scope.visible = !$scope.visible;
                }
            },
            transclude: true,
            scope: {
                title: '@'
            }
        }
    })
})();