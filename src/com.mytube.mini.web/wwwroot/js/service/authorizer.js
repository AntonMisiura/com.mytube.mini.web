'use strict';

/*
 *
 */
tubeApp.factory('authService', function (usersRepo) {

    var srv = {};

    srv.currUser = {
        logined: false
    };

    srv.login = function (login, password) {
        return usersRepo.login(login, password).then(function(r) {
            srv.currUser = r.data;
            srv.currUser.logined = true;
            return srv.currUser;
        });
    }


    srv.logout = function () {
        srv.currUser = {
            logined: false
        };
    }

    return srv;
});