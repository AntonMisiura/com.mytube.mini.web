"use strict";

tubeApp.controller("addVideoController", function ($scope, usersRepo, $mdDialog, authService) {

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});