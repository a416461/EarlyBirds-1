(function () {
    'use strict';

    angular
        .module('earlyBirdsApp')
        .config(config);
    
    config.$inject = ['$routeProvider', '$locationProvider'];

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/mainPage',
            {
                templateUrl: '/templates/MainPage.html',
                controller: 'MainPageController',
                controllerAs: 'vm'
            })
            .when('/about',
            {
                templateUrl: '/templates/About.html',
                controller: 'AboutController',
                controllerAs: 'vm'
            })
            .when('/home',
            {
                templateUrl: '/templates/Home.html',
                controller: 'HomeController',
                controllerAs: 'vm'
            })
            .otherwise({
                redirectTo: '/home'
            });

        $locationProvider.html5Mode(true);
    }
}());