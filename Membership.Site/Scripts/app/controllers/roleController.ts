module Membership {

    export class RoleController {
        static $inject = ['$scope', 'roleServices'];
        constructor($scope: any, roleServices: IRoleServices) {
            $scope.role = new Role();
            $scope.userName = "";
            $scope.findAll = () => { roleServices.findAll().then(data => { $scope.roles = data; }) }
            $scope.create = () => { roleServices.createRole($scope.role.roleName).then(data => { $scope.role = data; }); }
            $scope.getByName = () => { roleServices.getByName($scope.role.roleName).then(data => { $scope.role = data; }); }
            $scope.deleteRole = () => { roleServices.deleteRole($scope.role.roleName); }
            $scope.addUserToRole = () => { roleServices.addUserToRole($scope.userName, $scope.role.roleName); }
            $scope.removeUserFromRole = () => { roleServices.removeUserFromRole($scope.userName, $scope.role.roleName); }
            $scope.findRolesForUser = () => { roleServices.findRolesForUser($scope.userName).then(data => { $scope.roles = data; }); }
            $scope.findUsersInRole = () => { roleServices.findUsersInRole($scope.role.roleName).then(data => { $scope.users = data; }); }
        }
    }
}