module Membership {
    declare var toastr;
    export class UserController {
        static $inject = ['$scope', '$location', 'userServices', '$routeParams'];

        constructor($scope: any, $location: any, userServices: IUserServices, $routeParams: any) {
            $scope.user = new User();
            $scope.password = "";
            const locationUrl = $location.path();

            $scope.findAll = () => {
                userServices.findAll().then(data => {
                        $scope.users = data;
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
                userServices.createUser($scope.user.userName, $scope.user.email, $scope.password).then(() => {
                        $location.path("/users");
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.getByName = (userName) => {
                userServices.getByName(userName).then(data => {
                        $scope.user = data;
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.search = () => {
                userServices.getByName($scope.user.userName).then(data => {
                        $scope.users = [];
                        $scope.users.push(data);
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.delete = (userName) => {
                if (confirm("Are you sure you want delete this user?")) {
                    userServices.deleteUser(userName).then($scope.findAll,
                        data => {
                            if (!data) {
                                toastr.error("An error has ocurred.");
                            } else {
                                toastr.error(data.error);
                            }
                        });
                }
            };
            $scope.updateUser = () => {
                userServices.updateUser($scope.user, $scope.user.email).then(() => {
                        $location.path("/users");
                    },
                    data => {
                        if (!data) {
                            toastr.error("An error has ocurred.");
                        } else {
                            toastr.error(data.error);
                        }
                    });
            };
            $scope.edit = (userName) => {
                $location.path(`/users/update/${userName}`);
            };
            if (locationUrl === "/users/list") {
                $scope.findAll();
            } else if (locationUrl.toString().startsWith("/users/update")) {
                $scope.getByName($routeParams.userName);
            }
        }
    }
}