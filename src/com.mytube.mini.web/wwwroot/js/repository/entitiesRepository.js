'use strict';

tubeApp.factory("videosRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/videos");
    //extend or override repository here
    return repo;
});

tubeApp.factory("usersRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    return repo;
});

tubeApp.factory("ratingsRepo", function ($http, BaseRepository) {
    var repo = new BaseRepository("api/users");
    return repo;
});
//TODO READ aBout PROMISES and PROTOTAPE in JS