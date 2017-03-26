tubeApp.controller("myvideoController", function ($scope, $mdDialog, videosRepo) {
    $scope.imagePath = "img/washedout.png";

    $scope.r = videosRepo;

    // load videos
    $scope.videos = [];
    videosRepo.all().then(function(r) {
        $scope.videos = r.data;
    },
        function (error) {
            $scope.status = "Unable to load videos: " + error.message;
        });

    $scope.showVideoPage = function ($event) {
        var vDlg = $mdDialog.prompt({
            templateUrl: "views/dialogs/video.html",
            parent: angular.element(document.body),
            resolve: {},
            targetEvent: $event,
            clickOutsideToClose: true
        });
        $mdDialog.show(vDlg).then(function () {

        });
    }
});
