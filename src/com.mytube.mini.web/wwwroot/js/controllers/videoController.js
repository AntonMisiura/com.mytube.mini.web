tubeApp.controller("videoController", function ($scope, $http, videosRepo, ratingsRepo, $mdDialog, video, authService) {

    $scope.r = videosRepo;
    $scope.v = video;
    $scope.myproperty = 5;
    $scope.videos = [];
    $scope.ratings = [];
    $scope.currentUserName = authService.currUser.name;

    $scope.comment = {
        UserId: authService.currUser.id,
        VideoId: video.id,
        Comment: "",
        Mark: 4
    };

    $scope.addComment = function() {
        ratingsRepo.add($scope.comment).then(function(r) {
            console.log("Successfully added comment");
        });
    };

    $scope.showComments = function() {
        ratingsRepo.getForVideo(video.id).then(function(r) {
            $scope.ratings = r.data;
        });
    };

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});