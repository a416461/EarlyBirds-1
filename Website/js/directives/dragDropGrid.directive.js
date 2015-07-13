(function () {
    'use strict';

    angular
        .module('earlyBirdsApp')
        .directive('dragDropGrid', dragDropGrid);
    
    function dragDropGrid() {
        var directive = {
            restrict: 'E',
            replace: true,
            templateUrl: '/templates/directives/drag-drop-grid.html',
            controller: DragDropGridController,
            controllerAs: 'vm'
        };
        return directive;
    }

    DragDropGridController.$inject = ['$scope', 'gridEventHelper', 'serverCommunication'];

    function DragDropGridController($scope, gridEventHelper, serverCommunication) {
        var vm = this;
        vm.tiles = [
            {
                title: "Channels"
            },
            {
                title: "Users"
            },
            {
                title: "User Channels"
            }
        ];
        vm.addTile = addTile;

        let held = null;
        let ground = null;

        activation();

        function activation() {
            registerTiles();

       //     serverCommunication
       //         .getUserChannels()
       //         .then(channelsSuccess, channelsError);
        }

        function channelsSuccess(channels) {
            channels.forEach(function (element, index, array) {
                vm.tiles = vm.tiles.concat([{ title: element.name }]);
            });
        }

        function channelSuccess(channel) {
            //console.log("got " + channel.toSource());
            //console.log(JSON.stringify(channel));
            let tile = {
                title: channel.name
            }
            let isContained = false;
            let i = 0;
            vm.tiles.forEach(function (element, index, array) {
                if (element.title === channel.name) {
                    isContained = true;
                    i = index;
                }
                });
            if (!isContained){
                vm.tiles.push(tile);
            } else {
                vm.tiles.splice(i, 1);
            }
        }

        function channelsError(statusCode) {
            console.log(statusCode);
        }

        function registerTiles() {
            gridEventHelper.registerDrag(function (args) {
                held = args.target;
            });

            gridEventHelper.registerDrop(function (args) {
                // deleteTile(args.target.getAttribute('data-title'));
            });

            gridEventHelper.registerDroppedUpon(function (args) {
                ground = args.target;
                switchTiles(ground.getAttribute('data-title'), held.getAttribute('data-title'));
            });
        }

        function switchTiles(t1, t2) {
            if (t1 === null || t2 === null || vm.length <= 1) {
                return;
            }
            let temp1 = null;
            let temp2 = null;
            for (let i = vm.tiles.length - 1; i >= 0; i--) {
                if (vm.tiles[i].title === t1) {
                    temp1 = i;
                }
                if (vm.tiles[i].title === t2) {
                    temp2 = i;
                }
            }
            let temp = vm.tiles[temp1];
            vm.tiles[temp1] = vm.tiles[temp2];
            vm.tiles[temp2] = temp;
            $scope.$apply();
        }

        function deleteTile(title) {
            let search_term = title;
            for (let i = vm.tiles.length - 1; i >= 0; i--) {
                if (vm.tiles[i].title === search_term) {
                    vm.tiles.splice(i, 1);
                    break;
                }
            }
            vm.$apply();
        }

        function addTile(txt) {
            console.log("adding tile " + txt);
            serverCommunication
                .getChannel(txt)
                .then(channelSuccess, channelsError);
        };
    }
})();