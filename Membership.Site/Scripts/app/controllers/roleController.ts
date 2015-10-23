module Membership {

    export class RoleController {
        static $inject = ['$scope', '$location', 'roleServices', '$routeParams'];

        constructor($scope: any, $location: any, roleServices: IRoleServices, $routeParams: any) {
            $scope.role = new Role();
            $scope.userName = "";
            const locationUrl = $location.path();

            $scope.findAll = () => {
                roleServices.findAll().then(data => {
                    $scope.roles = data;
                });
            }

            $scope.create = () => {
                roleServices.createRole($scope.role.roleName).then(data => {
                    $scope.role = data;
                });
            }

            $scope.getByName = () => {
                roleServices.getByName($scope.role.roleName).then(data => {
                    $scope.role = data;
                });
            }

            $scope.deleteRole = () => {
                roleServices.deleteRole($scope.role.roleName);
            }

            $scope.addUserToRole = () => {
                roleServices.addUserToRole($scope.userName, $scope.role.roleName);
            }

            $scope.removeUserFromRole = () => {
                roleServices.removeUserFromRole($scope.userName, $scope.role.roleName);
            }

            $scope.findRolesForUser = () => {
                roleServices.findRolesForUser($scope.userName).then(data => {
                    $scope.roles = data;
                });
            }

            $scope.findUsersInRole = () => {
                roleServices.findUsersInRole($scope.role.roleName).then(data => {
                    $scope.users = data;
                });
            }

            $scope.edit = (name) => {
                $location.path(`/roles/update/${name}`);
            }

            if (locationUrl === "/roles/list") {
                $scope.findAll();
            }
            else if (locationUrl.toString().startsWith("/roles/update")) {
                $scope.getByName($routeParams.roleName);
            }
        }
    }
}