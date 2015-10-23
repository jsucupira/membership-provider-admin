module Membership {

    export class RoleController {
        static $inject = ['$scope', '$location', 'roleServices', '$routeParams'];

        constructor($scope: any, $location: any, roleServices: IRoleServices, $routeParams: any) {
            $scope.role = new Role();
            const locationUrl = $location.path();

            $scope.findAll = () => {
                roleServices.findAll().then(data => {
                    $scope.roles = data;
                });
            }

            $scope.create = () => {
                roleServices.createRole($scope.role.name).then(() => {
                    $location.path("/roles");
                });
            }

            $scope.getByName = (name) => {
                roleServices.getByName(name).then(data => {
                    $scope.role = data;
                    $scope.role.newName = $scope.role.name;
                });
            }

            $scope.search = () => {
                roleServices.getByName($scope.role.name).then(data => {
                    $scope.roles = [];
                    $scope.roles.push(data);
                });
            }

            $scope.deleteRole = (name) => {
                if (confirm("Are you sure you want delete this role?")) {
                    roleServices.deleteRole(name).then($scope.findAll);
                }
            }

            $scope.addUserToRole = () => {
                roleServices.addUserToRole($scope.userName, $scope.role.name);
            }

            $scope.removeUserFromRole = () => {
                roleServices.removeUserFromRole($scope.userName, $scope.role.name);
            }

            $scope.findRolesForUser = () => {
                roleServices.findRolesForUser($scope.userName).then(data => {
                    $scope.roles = data;
                });
            }

            $scope.findUsersInRole = () => {
                roleServices.findUsersInRole($scope.role.name).then(data => {
                    $scope.users = data;
                });
            }

            $scope.edit = (name) => {
                $location.path(`/roles/update/${name}`);
            }

            $scope.update = () => {
                if (confirm("Are you sure you want rename the role?")) {
                    roleServices.updateRole($scope.role.name, $scope.role.newName).then(() => {
                        $location.path(`/roles`);
                    });
                }
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