(function () {
    'use strict';
    var appController = angular.module("Membership.Site");

    appController.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/roles',
                {
                    title: 'Roles Page',
                    templateUrl: './scripts/app/templates/roles/index.html',
                    controller: 'roleController'
                })
                .when('/roles/create',
                {
                    title: 'Create Role',
                    templateUrl: '/scripts/app/templates/roles/create.html',
                    controller: 'roleController'
                })
                .when('/roles/list',
                {
                    title: 'List Roles',
                    templateUrl: '/scripts/app/templates/roles/list.html',
                    controller: 'roleController'
                })
                .when('/roles/search',
                {
                    title: 'Search Roles',
                    templateUrl: '/scripts/app/templates/roles/search.html',
                    controller: 'roleController'
                })
                .when('/roles/update/:roleName',
                {
                    title: 'Edit Role',
                    templateUrl: '/scripts/app/templates/roles/edit.html',
                    controller: 'roleController'
                });
    }]);

    appController.service('roleServices', Membership.RoleServices);
    appController.controller('roleController', Membership.RoleController);
})();