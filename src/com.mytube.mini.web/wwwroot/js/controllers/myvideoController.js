tubeApp.controller("myvideoController", function ($scope, videosRepo) {
    $scope.imagePath = "img/washedout.png";

    // TODO: Move to repository
    $scope.r = videosRepo;

    // load videos
    $scope.videos = [];
    videosRepo.all().then(function(r) {
        $scope.videos = r.data;
    },
        function (error) {
            $scope.status = "Unable to load videos: " + error.message;
    });
});
