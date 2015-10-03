(function () {

    'use strict';

    // Create the modules and define its dependencies.

    var app = angular.module('Membership.Site', ['ngRoute']);
    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider.otherwise({ redirectTo: '/' });
        }
    ]
);

    app.config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
    }]);


    app.run(['$location', '$rootScope', function ($location, $rootScope) {
        $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
            if (current.$$route) {
                $rootScope.title = current.$$route.title;
            }
        });
    }]);
})();