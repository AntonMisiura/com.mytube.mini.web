tubeApp.controller("userpageController", function ($rootScope, $scope, $state, $http, videosRepo, authService) {

    $scope.go = function (page) {
        $state.go(page);
    }

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        if (toState.name === 'userpage') {
            videosRepo.getForUser(authService.currUser.id).then(function (r) {
                $scope.videos = r.data;
            });
        };
    });

    $scope.upload = function() {
        angular.element(document.querySelector("#fileInput")).click();
    };

    /**
     * Load all videos
     */
    $scope.videos = [];
    videosRepo.getForUser(authService.currUser.id).then(function (r) {
        $scope.videos = r.data;
    });

    $scope.r = videosRepo;

    $scope.files = {}; // list of uploaded files by user

    $scope.$watch('files.length',function(newVal,oldVal){
        console.log($scope.files);
    });

    $scope.addVideo = function () {

        //TODO read about FORMDATA and Headers
        var formData = new FormData();
        angular.forEach($scope.files, function (file) {
            if (!file.isRemote) {
                formData.append('files[]', file.lfFile);
            }
        });
        formData.append('metadata', JSON.stringify($scope.video));

        // TODO: Move to repository
        $http.post('api/videos/upload', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (r) {
            $scope.videos.push(r.data);
        }, function (err) {
            // do sometingh
        });
    };

    $scope.video = {
        Name: '',
        UserId: authService.currUser.id,
    };

    //add video
    //$scope.addVideo = function() {
    //    videosRepo.add($scope.video).then(function (r) {
    //        //$scope.videos.push({Id: 1, UserId: 1, Name: Addedvideo, Path: "/path/addedvideo", ScreenPath: "scr", CreatedDate: 2017-03-13});
    //        $scope.videos.push(r.data);
    //    });
    //};
});