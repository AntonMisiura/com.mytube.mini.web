"use strict";

var React = require("react");
var Router = require("react-router");
var Link = require("react-router").Link;
var UserStore = require("../../stores/userStore");
var UserActions = require("../../actions/userActions");
var UserList = require("./userList");

var UserPage = React.createClass({
    getInitialState: function(){
        return {
            users: UserStore.getAllUsers()
        };
    },

    componentWillMount: function() {
        UserStore.addChangeListener(this._onChange);
    },

    //Clean up when this component is unmounted
    componentWillUnMount: function() {
        UserStore.removeChangeListener(this._onChange);
    },

    _onChange: function() {
        this.setState({ users: UserStore.getAllUsers() });
    },

    render: function () {
        return (
            <div>
                <h1>Users</h1>
                <Link to="addUser" className="btn btn-default">Sign Up</Link>
                <Link to="addUser" className="btn btn-default">Login</Link>
                <UserList users={this.state.users} />
            </div>
        );
    }
});

module.exports = UserPage;