"use strict";

var Dispatcher = require("../dispatcher/appDispatcher");
var ActionTypes = require("../constants/actionTypes");
var UserApi = require("../api/userApi");

var InitializeActions = {
    initApp: function () {
        Dispatcher.dispatch({
            actionType: ActionTypes.INITIALIZE,
            initialData: {
                users: UserApi.getAllUsers()
            }
        });
    }
};

module.exports = InitializeActions;