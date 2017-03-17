"use strict";

tubeApp.factory("videosRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/videos");
    //extend or override repository

    repo.getPath = function (v) {
        return "api/videos/content/" + v.id;
    }

    repo.getForUser = function (id) {
        return $http.get(this.baseurl + "/users/"+id);
    }

    return repo;
});

tubeApp.factory("usersRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    //extend or override functions

    repo.login = function(login, password) {
        return $http.post(this.baseurl + "/login", {Login: login, Password: password});
    }

    return repo;
});

tubeApp.factory("ratingsRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    //extend or override functions

    return repo;
});
