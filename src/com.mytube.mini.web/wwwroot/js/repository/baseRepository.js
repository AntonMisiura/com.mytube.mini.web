"use strict";

/*
 *
 */
tubeApp.factory("BaseRepository", function ($http) {

    var baseRepository = function (baseurl) {

        this.baseurl = baseurl;

        this.objToParam = function (obj) {
            var params = {};
            for (var property in obj) {
                var value = obj[property];

                if (value === null || value === "" || value === undefined)
                    continue;

                //if (moment.isMoment(value))
                //    value = value.format('YYYY-MM-DD HH:mm:ss');

                params[property] = value;
            }

            return jQuery.param(params);
        }
    }

    //
    // Move to promises (Q library)
    baseRepository.prototype = {

        count: function (filter) {
            var params = filter ? "?" + this.objToParam(filter) : "";
            return $http.get(this.baseurl + "/count" + params);
        },

        all: function (filter) {
            var params = filter ? "?" + this.objToParam(filter) : "";
            return $http.get(this.baseurl + params);
        },

        get: function (id) {
            return $http.get(this.baseurl + "/" + id);
        },

        add: function (entity) {
            return $http.post(this.baseurl, entity);
        },

        remove: function (id) {
            return $http.post(this.baseurl + "/remove", { id: id });
        }
    }

    return baseRepository;
});