tubeApp.controller("videoController", function ($scope, $http, videosRepo, $mdDialog, authService) {

    $scope.myproperty = 5;
    $scope.videos = [];
    videosRepo.all().then(function (r) {
        $scope.videos = r.data;
    },
        function (error) {
            $scope.status = "Unable to load videos: " + error.message;
        });

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});