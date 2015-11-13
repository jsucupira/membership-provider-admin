module Membership {
    declare var toastr;
    export class RoleController {
        static $inject = ['$scope', '$location', 'roleServices', '$routeParams'];

        constructor($scope: any, $location: any, roleServices: IRoleServices, $routeParams: any) {
            $scope.role = new Role();
            $scope.userName = "";
            const locationUrl = $location.path();

            $scope.findAll = () => {
                roleServices.findAll().then(data => {
                        $scope.roles = data;
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.create = () => {
                roleServices.createRole($scope.role.name).then(() => {
                        $location.path("/roles");
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.getByName = (name) => {
                roleServices.getByName(name).then(data => {
                        $scope.role = data;
                        $scope.role.newName = $scope.role.name;
                        $scope.findUsersInRole();
                    }),
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    };
            };
            $scope.search = () => {
                roleServices.getByName($scope.role.name).then(data => {
                        $scope.roles = [];
                        $scope.roles.push(data);
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.deleteRole = (name) => {
                if (confirm("Are you sure you want delete this role?")) {
                    roleServices.deleteRole(name).then($scope.findAll);
                }
            };
            $scope.addUserToRole = () => {
                roleServices.addUserToRole($scope.userName, $scope.role.name).then(() => {
                        $scope.findUsersInRole();
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.removeUserFromRole = (name) => {
                roleServices.removeUserFromRole(name, $scope.role.name).then(() => {
                        $scope.findUsersInRole();
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.findRolesForUser = () => {
                roleServices.findRolesForUser($scope.userName).then(data => {
                        $scope.roles = data;
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.findUsersInRole = () => {
                roleServices.findUsersInRole($scope.role.name).then(data => {
                        $scope.role.users = data;
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.edit = (name) => {
                $location.path(`/roles/update/${name}`);
            };
            $scope.update = () => {
                if (confirm("Are you sure you want rename the role?")) {
                    roleServices.updateRole($scope.role.name, $scope.role.newName).then(() => {
                        $location.path(`/roles`);
                    });
                }
            };
            if (locationUrl === "/roles/list") {
                $scope.findAll();
            } else if (locationUrl.toString().startsWith("/roles/update")) {
                $scope.getByName($routeParams.roleName);
            }
        }
    }
}