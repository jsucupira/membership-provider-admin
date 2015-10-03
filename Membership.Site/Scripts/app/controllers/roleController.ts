module Membership {

    export class RoleController {
        static $inject = ['$scope', 'roleServices'];
        constructor($scope: any, roleServices: IRoleServices) {
            $scope.role = new Role();
            $scope.userName = "";
            $scope.findAll = () => { $scope.roles = roleServices.findAll(); }
            $scope.create = () => { $scope.role = roleServices.createRole($scope.role.roleName); }
            $scope.getByName = () => { $scope.role = roleServices.getByName($scope.role.roleName); }
            $scope.deleteRole = () => { roleServices.deleteRole($scope.role.roleName); }
            $scope.addUserToRole = () => { roleServices.addUserToRole($scope.userName, $scope.role.roleName); }
            $scope.removeUserFromRole = () => { roleServices.removeUserFromRole($scope.userName, $scope.role.roleName); }
            $scope.findRolesForUser = () => { $scope.roles = roleServices.findRolesForUser($scope.userName); }
            $scope.findUsersInRole = () => { $scope.users = roleServices.findUsersInRole($scope.role.roleName); }
        }
    }
}