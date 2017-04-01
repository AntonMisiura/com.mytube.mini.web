
tubeApp.config(function ($stateProvider, $mdThemingProvider) {

    /*
     * Config angular materials
     */
    $mdThemingProvider.theme("default")
        .primaryPalette("brown")
        .accentPalette("green");
    /**
     * Config routes
     */
    $stateProvider
        .state("home", {
            url: "/home",
            templateUrl: "/views/home/home.html",
            controller: "HomeController"
        }).
        state("videos", {
            url: "/videos",
            templateUrl: "/views/myvideos.html",
            controller: "myvideoController"
        }).
        state("help", {
            url: "/help",
            templateUrl: "/views/help.html",
            controller: "helpController"
        }).
        state("userpage", {
            url: "/userpage",
            templateUrl: "/views/userpage.html",
            controller: "userpageController"
        }).
        state("addvideo", {
            url: "/addvideo",
            templateUrl: "/views/dialogs/addVideo.html",
            controller: "addVideoController"
        });
});