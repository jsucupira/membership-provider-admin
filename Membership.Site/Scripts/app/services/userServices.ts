/// <reference path="../../typings/angularjs/angular.d.ts" />
module Membership {
    import Constants = Helpers.Constants;

    export interface IUserServices {
        createUser(userName: string, email: string, password: string);
        findAll(): ng.IPromise<User[]>;
        getByName(userName: string): ng.IPromise<User>;
        deleteUser(userName: string);
    }

    export class UserServices implements IUserServices {
        static $inject = ['$http', '$q'];

        private httpService: any;
        private async: any;

        constructor($http: any, $q: any) {
            this.httpService = $http;
            this.async = $q;
        }

        createUser(userName: string, email: string, password: string) {
            var deferred = this.async.defer();
            var user = new UserRequest();
            user.userName = userName;
            user.email = email;
            user.password = password;

            this.httpService({
                method: "POST",
                url: Constants.apiBase() + "/users",
                data: user
            }).success(data => {
                deferred.resolve(data);
                return data;
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;
        }

        findAll(): ng.IPromise<User[]> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/users"
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        getByName(userName: string): ng.IPromise<User> {
            var deferred = this.async.defer();
            this.httpService({
                method: "GET",
                url: Constants.apiBase() + "/users/" + userName
            }).success(data => {
                deferred.resolve(data);
            }).error(err => {
                console.log(err);
                deferred.reject(err);
            });;
            return deferred.promise;
        }

        deleteUser(userName: string) {
            var deferred = this.async.defer();
            this.httpService({
                method: "DELETE",
                url: Constants.apiBase() + "/users/" + userName
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