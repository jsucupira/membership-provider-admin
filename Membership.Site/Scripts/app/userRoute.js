(function () {
    'use strict';
    var appController = angular.module("Membership.Site");

    appController.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/users',
            {
                title: 'User Page',
                templateUrl: '/scripts/app/templates/users/index.html',
                controller: 'userController'
            }).when('/',
            {
                title: 'User Page',
                templateUrl: '/scripts/app/templates/users/index.html',
                controller: 'userController'
            })
            .when('/users/create',
            {
                title: 'Create User',
                templateUrl: '/scripts/app/templates/users/create.html',
                controller: 'userController'
            })
            .when('/users/list',
            {
                title: 'List User',
                templateUrl: '/scripts/app/templates/users/list.html',
                controller: 'userController'
            })
            .when('/users/update/:userName',
            {
                title: 'Edit User',
                templateUrl: '/scripts/app/templates/users/edit.html',
                controller: 'userController'
            });
    }]);

    appController.service('userServices', Membership.UserServices);
    appController.controller('userController', Membership.UserController);
})();