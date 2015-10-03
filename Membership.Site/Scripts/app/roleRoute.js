(function () {
    'use strict';
    var appController = angular.module("Membership.Site");

    appController.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/',
                {
                    title: 'Roles Page',
                    templateUrl: './scripts/app/templates/roles/index.html',
                    controller: 'roleController'
                });
    }]);

    appController.service('roleServices', Membership.RoleServices);
    appController.controller('roleController', Membership.RoleController);
})();