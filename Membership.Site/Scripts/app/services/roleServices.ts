/// <reference path="../../typings/angularjs/angular.d.ts" />

module Membership {
    import Constants = Helpers.Constants;

    export interface IRoleServices {
        addUserToRole(userName: string, roleName: string);
        createRole(name: string);
        findAll(): ng.IPromise<Role[]>;
        getByName(roleName: string): ng.IPromise<Role>;
        deleteRole(roleName: string);
        removeUserFromRole(userName: string, roleName: string);
        findRolesForUser(userName: string): ng.IPromise<Role[]>;
        findUsersInRole(roleName: string): ng.IPromise<User[]>;
        updateRole(name, newName);
    }

    export class RoleServices implements IRoleServices {
        private httpService: any;
        private async: any;

        constructor($http: any, $q: any) {
            this.httpService = $http;
            this.async = $q;
        }

        addUserToRole(userName: string, roleName: string) {
            var deferred = this.async.defer();
            const userRoleRequest = new UserRoleRequest();
            userRoleRequest.roleName = roleName;
            userRoleRequest.userName = userName;
            this.httpService({
                method: "PUT",
                url: Constants.apiBase() + "/roles/" + roleName + "/users",
                data: userRoleRequest
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        createRole(name: string) {
            var deferred = this.async.defer();
            var userRole = new RoleRequest();
            userRole.name = name;

            this.httpService({
                method: "POST",
                url: Constants.apiBase() + "/roles",
                data: userRole
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        findAll(): ng.IPromise<Role[]> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles"
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        getByName(roleName: string): ng.IPromise<Role> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/" + roleName
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        deleteRole(roleName: string) {

            var deferred = this.async.defer();
            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/roles/" + roleName
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        removeUserFromRole(userName: string, roleName: string) {
            var deferred = this.async.defer();

            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/roles/" + roleName + "/users?userName=" + userName
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        findRolesForUser(userName: string): ng.IPromise<Role[]> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/users/" + userName + "/roles"
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        findUsersInRole(roleName: string): ng.IPromise<User[]> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/roles/" + roleName + "/users"
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        updateRole(name, newName) {
            var deferred = this.async.defer();
            var roleRequest = new RoleRequest();
            roleRequest.name = name;
            roleRequest.newName = newName;

            this.httpService({
                method: "PUT",
                url: Constants.apiBase() + "/roles/" + name,
                data: roleRequest
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }
    }
}