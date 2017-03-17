"use strict";

tubeApp.controller("regUserController", function ($scope, usersRepo, $mdDialog) {

    // The new user
    $scope.newUser = {
        Login: "",
        Name: "",
        Password: ""
    };

    $scope.regUser = function() {

        // validate user
        //if (!$scope.newUser.Login) alert();

        usersRepo.add($scope.newUser).then(function (r) {
            // register success, redirect to home page
            $mdDialog.hide();
        });
    };

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});