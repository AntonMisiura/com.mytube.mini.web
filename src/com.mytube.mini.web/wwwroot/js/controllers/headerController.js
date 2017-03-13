'use strict';

/**
 *
 */
tubeApp.controller('headerController', function($scope, $state) {

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

    $scope.login = function() {
        $scope.user.logined = true;
    }

    $scope.logout = function () {
        $scope.user.logined = false;
    }
});

