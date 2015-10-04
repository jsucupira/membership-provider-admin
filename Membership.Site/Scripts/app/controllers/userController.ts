module Membership {

    export class UserController {
        static $inject = ['$scope', '$location', 'userServices'];
        constructor($scope: any, $location: any, userServices: IUserServices) {
            $scope.user = new User();
            $scope.password = "";
            $scope.findAll = () => { userServices.findAll().then(data => { $scope.users = data; }); }
            $scope.create = () => { userServices.createUser($scope.user.userName, $scope.user.email, $scope.password).then(data => { $scope.user = data; });
            }
            $scope.getByName = () => { userServices.getByName($scope.user.userName).then($scope.user); }
            $scope.deleteUser = () => { userServices.deleteUser($scope.user.userName); }

            if ($location.path() === "/users/list") {
                $scope.findAll();
                console.log("got it");
            }
        }
    }
}