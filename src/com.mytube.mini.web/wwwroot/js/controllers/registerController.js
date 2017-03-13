(function () {
    "use strict";
    tubeApp
        .controller("registerController", registerCtrl);

    //tubeApp.controller("registerController", function($scope, usersRepo) {

    //$scope.addUser = function () {
    //    var name = $scope.username;
    //    var login = $scope.login;
    //    var password = $scope.password;
    //    console.log("name :" + name + "login : " + login + "password : " + password);

    //    $scope.users = [];
    //    var user = {
    //        Name: username,
    //        Login: login,
    //        Password: password
    //    };

    //    //usersRepo.add(user).then(function (r) {
    //    //    $scope.users.push(user);
    //    //});


    //};
    //});

    function registerCtrl ($mdDialog) {
        var self = this;

        self.openDialog = function ($event) {
            $mdDialog.show({
                controller: dialogCtrl,
                controllerAs: "ctrl",
                templateUrl: "views/dialogs/register.html",
                parent: tubeApp.element,
                targetEvent: $event,
                clickOutsideToClose: true
            });
        }
    }

    function dialogCtrl($timeout, $q, $scope, $mdDialog) {
        var self = this;

        self.cancel = function ($event) {
            $mdDialog.cancel();
        };
        self.finish = function ($event) {
            $mdDialog.hide();
        };
    }
})();