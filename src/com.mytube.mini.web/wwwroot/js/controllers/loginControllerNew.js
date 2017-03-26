"use strict";

tubeApp.controller("loginNewController", function ($scope, usersRepo, $mdDialog, authService) {

    // The new user
    $scope.user = {
        Login: "",
        Password: ""
    };

    $scope.login = function() {

        // validate user
        //if (!$scope.newUser.Login) alert();

        authService.login($scope.user.Login, $scope.user.Password).then(function (u) {
            // logging in success, redirect to home page
            $mdDialog.hide(u);
        });
    };

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});