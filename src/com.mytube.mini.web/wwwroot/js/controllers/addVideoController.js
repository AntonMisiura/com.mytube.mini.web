tubeApp.controller("addVideoController", function ($scope, $http, videosRepo, $mdDialog, authService) {


    $scope.videos = [];
    videosRepo.getForUser(authService.currUser.id).then(function (r) {
        $scope.videos = r.data;
    });

    $scope.r = videosRepo;
    $scope.files = {};

    $scope.addVideo = function () {
        var formData = new FormData();
        angular.forEach($scope.files, function (file) {
            if (!file.isRemote) {
                formData.append("files[]", file.lfFile);
            }
        });
        formData.append("metadata", JSON.stringify($scope.video));

        $http.post("api/videos/upload", formData, {
            transformRequest: angular.identity,
            headers: { "Content-Type": undefined }
        }).then(function (r) {
            $scope.videos.push(r.data);
        }, function (err) {
            // if error
        });
    };

    $scope.video = {
        Name: "",
        UserId: authService.currUser.id
    };

    $scope.cancel = function ($event) {
        $mdDialog.cancel();
    };
});