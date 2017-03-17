'use strict';

/**
 *
 */
tubeApp.controller('headerController', function ($scope, $state, $mdDialog, authService) {

    $scope.menu = [
        { name: "My Videos", path: "videos" },
        { name: "Help", path: "help" }
    ];

    $scope.go = function (page) {
        $state.go(page);
    }

    $scope.user = {
        logined: false
    };

    $scope.login = function (ev) {

        var regDlg = $mdDialog.prompt({
            templateUrl: "views/dialogs/login.html",
            parent: angular.element(document.body),
            resolve: {},
            targetEvent: ev,
            clickOutsideToClose: true
        });

        $mdDialog.show(regDlg).then(function (u) {
            $scope.user = u;
        });

        //authService.login('sherlok', 'sherlok').then(function (u) {
        //    $scope.user = u;
        //});
    }

    $scope.logout = function () {
        authService.logout();
        $scope.user.logined = false;
        $state.go('videos');
    }

    $scope.register = function ($event) {
        var regDlg = $mdDialog.prompt({
            templateUrl: "views/dialogs/register.html",
            parent: angular.element(document.body),
            resolve: {},
            targetEvent: $event,
            clickOutsideToClose: true
        });

        $mdDialog.show(regDlg).then(function () {
            // TODO: change header
        });
    }

});

