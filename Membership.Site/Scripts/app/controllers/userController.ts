module Membership {

    export class UserController {
        static $inject = ['$scope', '$location', 'userServices', '$routeParams'];
        constructor($scope: any, $location: any, userServices: IUserServices, $routeParams:any) {
            $scope.user = new User();
            $scope.password = "";
            $scope.findAll = () => { userServices.findAll().then(data => { $scope.users = data; }); }
            $scope.create = () => { userServices.createUser($scope.user.userName, $scope.user.email, $scope.password).then(data => { $scope.user = data; }); }
            $scope.getByName = (userName) => { userServices.getByName(userName).then(data => { $scope.user = data; }); }
            $scope.deleteUser = (userName) => { userServices.deleteUser(userName); }
            $scope.updateUser = () => { userServices.updateUser($scope.user, $scope.email); }
            $scope.edit = (userName) => { $location.path(`/users/update/${userName}`);}

            var locationUrl = $location.path();
            if (locationUrl === "/users/list") {
                $scope.findAll();
                console.log("got it");
            }
            else if (locationUrl.toString().startsWith("/users/update")) {
                $scope.getByName($routeParams.userName);
            }
        }
    }
}