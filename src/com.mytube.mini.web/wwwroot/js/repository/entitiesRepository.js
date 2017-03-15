'use strict';

tubeApp.factory("videosRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/videos");
    //extend or override repository here

    repo.getPath = function (v) {
        return 'api/videos/content/' + v.id;
    }

    repo.getForUser = function (id) {
        return $http.get(this.baseurl + '/users/'+id);
    }

    return repo;
});

tubeApp.factory("usersRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    repo.login = function(login, password) {
        return $http.post(this.baseurl + '/login', {Login: login, Password: password});
    }
    return repo;
});

tubeApp.factory("ratingsRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    return repo;
});
//TODO READ aBout PROMISES and PROTOTAPE in JS