(function () {
    'use strict';
    var appController = angular.module("Membership.Site");

    appController.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/users',
                {
                    title: 'User Page',
                    templateUrl: './scripts/app/templates/users/index.html',
                    controller: 'userController'
                });
    }]);

    appController.service('userServices', Membership.UserServices);
    appController.controller('userController', Membership.UserController);
})();