var Membership;
(function (Membership) {
    var RoleController = (function () {
        function RoleController($scope, $location, roleServices, $routeParams) {
            $scope.role = new Membership.Role();
            $scope.userName = "";
            var locationUrl = $location.path();
            $scope.findAll = function () {
                roleServices.findAll().then(function (data) {
                    $scope.roles = data;
                });
            };
            $scope.create = function () {
                roleServices.createRole($scope.role.name).then(function () {
                    $location.path("/roles");
                });
            };
            $scope.getByName = function (name) {
                roleServices.getByName(name).then(function (data) {
                    $scope.role = data;
                    $scope.role.newName = $scope.role.name;
                    $scope.findUsersInRole();
                });
            };
            $scope.search = function () {
                roleServices.getByName($scope.role.name).then(function (data) {
                    $scope.roles = [];
                    $scope.roles.push(data);
                });
            };
            $scope.deleteRole = function (name) {
                if (confirm("Are you sure you want delete this role?")) {
                    roleServices.deleteRole(name).then($scope.findAll);
                }
            };
            $scope.addUserToRole = function () {
                roleServices.addUserToRole($scope.userName, $scope.role.name).then(function () {
                    $scope.findUsersInRole();
                });
            };
            $scope.removeUserFromRole = function (name) {
                roleServices.removeUserFromRole(name, $scope.role.name).then(function () {
                    $scope.findUsersInRole();
                });
            };
            $scope.findRolesForUser = function () {
                roleServices.findRolesForUser($scope.userName).then(function (data) {
                    $scope.roles = data;
                });
            };
            $scope.findUsersInRole = function () {
                roleServices.findUsersInRole($scope.role.name).then(function (data) {
                    $scope.role.users = data;
                });
            };
            $scope.edit = function (name) {
                $location.path("/roles/update/" + name);
            };
            $scope.update = function () {
                if (confirm("Are you sure you want rename the role?")) {
                    roleServices.updateRole($scope.role.name, $scope.role.newName).then(function () {
                        $location.path("/roles");
                    });
                }
            };
            if (locationUrl === "/roles/list") {
                $scope.findAll();
            }
            else if (locationUrl.toString().startsWith("/roles/update")) {
                $scope.getByName($routeParams.roleName);
            }
        }
        RoleController.$inject = ['$scope', '$location', 'roleServices', '$routeParams'];
        return RoleController;
    })();
    Membership.RoleController = RoleController;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var UserController = (function () {
        function UserController($scope, $location, userServices, $routeParams) {
            $scope.user = new Membership.User();
            $scope.password = "";
            var locationUrl = $location.path();
            $scope.findAll = function () {
                userServices.findAll().then(function (data) {
                    $scope.users = data;
                });
            };
            $scope.create = function () {
                userServices.createUser($scope.user.userName, $scope.user.email, $scope.password).then(function () {
                    $location.path("/users");
                });
            };
            $scope.getByName = function (userName) {
                userServices.getByName(userName).then(function (data) {
                    $scope.user = data;
                });
            };
            $scope.search = function () {
                userServices.getByName($scope.user.userName).then(function (data) {
                    $scope.users = [];
                    $scope.users.push(data);
                });
            };
            $scope.delete = function (userName) {
                if (confirm("Are you sure you want delete this user?")) {
                    userServices.deleteUser(userName).then($scope.findAll);
                }
            };
            $scope.updateUser = function () {
                userServices.updateUser($scope.user, $scope.user.email).then(function () {
                    $location.path("/users");
                });
            };
            $scope.edit = function (userName) {
                $location.path("/users/update/" + userName);
            };
            if (locationUrl === "/users/list") {
                $scope.findAll();
            }
            else if (locationUrl.toString().startsWith("/users/update")) {
                $scope.getByName($routeParams.userName);
            }
        }
        UserController.$inject = ['$scope', '$location', 'userServices', '$routeParams'];
        return UserController;
    })();
    Membership.UserController = UserController;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var Helpers;
    (function (Helpers) {
        var Constants = (function () {
            function Constants() {
            }
            Constants.templateBase = function () { return this.domain + "/app/templates"; };
            Constants.apiBase = function () { return this.domain + "/api"; };
            Constants.loginUrl = function () { return this.domain + "/Token"; };
            Constants.domain = "http://localhost:58133";
            return Constants;
        })();
        Helpers.Constants = Constants;
    })(Helpers = Membership.Helpers || (Membership.Helpers = {}));
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var UserRoleRequest = (function () {
        function UserRoleRequest() {
        }
        return UserRoleRequest;
    })();
    Membership.UserRoleRequest = UserRoleRequest;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var Role = (function () {
        function Role() {
        }
        return Role;
    })();
    Membership.Role = Role;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var RoleRequest = (function () {
        function RoleRequest() {
        }
        return RoleRequest;
    })();
    Membership.RoleRequest = RoleRequest;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var User = (function () {
        function User() {
        }
        return User;
    })();
    Membership.User = User;
})(Membership || (Membership = {}));

var Membership;
(function (Membership) {
    var UserRequest = (function () {
        function UserRequest() {
        }
        return UserRequest;
    })();
    Membership.UserRequest = UserRequest;
})(Membership || (Membership = {}));

/// <reference path="../../typings/angularjs/angular.d.ts" />
var Membership;
(function (Membership) {
    var Constants = Membership.Helpers.Constants;
    var RoleServices = (function () {
        function RoleServices($http, $q) {
            this.httpService = $http;
            this.async = $q;
        }
        RoleServices.prototype.addUserToRole = function (userName, roleName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "PUT",
                url: Constants.apiBase() + "/roles/" + roleName + "/users/" + userName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.createRole = function (name) {
            var deferred = this.async.defer();
            var userRole = new Membership.RoleRequest();
            userRole.name = name;
            this.httpService({
                method: "POST",
                url: Constants.apiBase() + "/roles",
                data: userRole
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.findAll = function () {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.getByName = function (roleName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/" + roleName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.deleteRole = function (roleName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/roles/" + roleName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.removeUserFromRole = function (userName, roleName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/roles/" + roleName + "/users/" + userName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.findRolesForUser = function (userName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/users/" + userName + "/roles"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.findUsersInRole = function (roleName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/" + roleName + "/users"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        RoleServices.prototype.updateRole = function (name, newName) {
            var deferred = this.async.defer();
            var roleRequest = new Membership.RoleRequest();
            roleRequest.name = name;
            roleRequest.newName = newName;
            this.httpService({
                method: "PUT",
                url: Constants.apiBase() + "/roles/" + name,
                data: roleRequest
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        return RoleServices;
    })();
    Membership.RoleServices = RoleServices;
})(Membership || (Membership = {}));

/// <reference path="../../typings/angularjs/angular.d.ts" />
var Membership;
(function (Membership) {
    var Constants = Membership.Helpers.Constants;
    var UserServices = (function () {
        function UserServices($http, $q) {
            this.httpService = $http;
            this.async = $q;
        }
        UserServices.prototype.createUser = function (userName, email, password) {
            var deferred = this.async.defer();
            var user = new Membership.UserRequest();
            user.userName = userName;
            user.email = email;
            user.password = password;
            this.httpService({
                method: "POST",
                url: Constants.apiBase() + "/users",
                data: user
            }).success(function (data) {
                deferred.resolve(data);
                return data;
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        };
        UserServices.prototype.findAll = function () {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/users"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        UserServices.prototype.updateUser = function (user, newEmail) {
            var deferred = this.async.defer();
            var userRequest = new Membership.UserRequest();
            userRequest.userName = user.userName;
            userRequest.email = user.email;
            userRequest.newEmail = newEmail;
            this.httpService({
                method: "PUT",
                url: Constants.apiBase() + "/users/" + user.userName,
                data: userRequest
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        UserServices.prototype.getByName = function (userName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/users/" + userName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        UserServices.prototype.deleteUser = function (userName) {
            var deferred = this.async.defer();
            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/users/" + userName
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            ;
            return deferred.promise;
        };
        UserServices.$inject = ['$http', '$q'];
        return UserServices;
    })();
    Membership.UserServices = UserServices;
})(Membership || (Membership = {}));
