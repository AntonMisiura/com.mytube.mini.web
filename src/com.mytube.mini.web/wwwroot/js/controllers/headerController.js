'use strict';

/**
 *
 */
tubeApp.controller('headerCtrl', function($scope, $state) {

    $scope.menu = [
        { name: 'My Videos', path: 'videos' },
        { name: 'Editor', path: '' },
        { name: 'Help', path: 'help' },
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

tubeApp.controller('myvideoCtrl', function($scope) {
    $scope.imagePath = 'img/washedout.png';
});

tubeApp.controller('helpCtrl', function ($scope) {

});