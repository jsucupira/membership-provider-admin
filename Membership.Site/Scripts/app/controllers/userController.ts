module Membership {

    export class UserController {
        static $inject = ['$scope', 'userServices'];
        constructor($scope: any, userServices: IUserServices) {
            $scope.user = new User();
            $scope.password = "";
            $scope.findAll = () => { $scope.users = userServices.findAll(); }
            $scope.create = () => { $scope.user = userServices.createUser($scope.user.userName, $scope.user.email, $scope.password); }
            $scope.getByName = () => { $scope.user = userServices.getByName($scope.user.userName); }
            $scope.deleteUser = () => { userServices.deleteUser($scope.user.userName); }
        }
    }
}