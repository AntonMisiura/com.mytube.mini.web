tubeApp.controller("userpageController", function ($rootScope, $scope, $mdDialog, $state, $http, videosRepo, ratingsRepo, authService) {

    $scope.go = function (page) {
        $state.go(page);
    }

    $rootScope.$on("$stateChangeSuccess", function (event, toState) {
        if (toState.name === "userpage") {
            //returns current user
            videosRepo.getForUser(authService.currUser.id).then(function (r) {
                //assigned current user id to videos
                $scope.videos = r.data;
            });
        };
    });

    /**
     * Load all videos
     */
    $scope.videos = [];
    videosRepo.getForUser(authService.currUser.id).then(function (r) {
        $scope.videos = r.data;
    });

    $scope.r = videosRepo;

    $scope.files = {}; // list of uploaded files by user

    //observing for files
    $scope.$watch("files.length",function(newVal,oldVal){
        console.log($scope.files);
    });

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

    $scope.showVideoPageAtUserPage = function($event, video) {
        var vDlg = $mdDialog.prompt({
            templateUrl: "views/dialogs/video.html",
            controller: "videoController",
            parent: angular.element(document.body),
            resolve: {
                video: function() {
                    return video;
                }
            },
            targetEvent: $event,
            clickOutsideToClose: true
        });
        $mdDialog.show(vDlg).then(function() {

        });
    }
});