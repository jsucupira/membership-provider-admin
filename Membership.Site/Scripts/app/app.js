(function () {

    'use strict';

    // Create the modules and define its dependencies.

    var app = angular.module('Membership.Site', ['ngRoute']);
    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider.when("/", {
                title: "Membership Provider Admin",
                template: "<h1>Welcome</h1><p>Click in one of the navigation links above</p>"
            }).otherwise({ redirectTo: '/' });
        }
    ]
);

    app.config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }]);


    app.run(['$location', '$rootScope', function ($location, $rootScope) {
        $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
            if (current.$$route) {
                $rootScope.title = current.$$route.title;
            }
        });
    }]);
})();