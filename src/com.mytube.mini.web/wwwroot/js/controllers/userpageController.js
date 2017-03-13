tubeApp.controller("userpageController", function ($scope, videosRepo) {

    $scope.upload = function() {
        angular.element(document.querySelector("#fileInput")).click();
    };


    //videosRepo.add().then(function (r) {
    //    $scope.status = "Inserted Customer! Refreshing customer list.";
    //    $scope.videos.push(r);
    //},
    //    function (error) {
    //        $scope.status = "Unable to add video: " + error.message;
    //    });

    $scope.addVideo = function() {
        var name = $scope.name;
        var screenPath = $scope.screenPath;
        var path = $scope.filePath;
        console.log("name :" + name + "screenpath : " + screenPath + "path : " + path);

        var video = {
            Name: name,
            ScreenPath: screenPath,
            Path: path
        };

        videosRepo.add(video).then(function(r){
            $scope.videos.push(video);
        });


    };
});