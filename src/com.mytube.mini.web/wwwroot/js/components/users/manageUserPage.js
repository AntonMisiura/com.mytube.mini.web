"use strict";

var React = require("react");
var Router = require("react-router");
var UserForm = require("./userForm");
var UserActions = require("../../actions/userActions");
var UserStore = require("../../stores/userStore");
var toastr = require("toastr");

var ManageUserPage = React.createClass({
    mixins: [
        Router.Navigation
    ],

    statics: {
        willTransitionFrom: function(transition, component){
            if (component.state.dirty && !confirm("Leave without saving?")) {
                transition.abort();
            }
        }
    },

    getInitialState: function() {
        return {
            user: { id: "", firstName: "", lastName: "", login: "", password: "" },
            errors: {},
            dirty: false
        };
    },

    componentWillMount: function() {
        var userId = this.props.params.id; // from the path "/user:id"

        if(userId) {
            this.setState({user: UserStore.getUserById(userId)});
        }
    },

    setUserState: function(event) {
        this.setState({dirty: true});
        var field = event.target.name;
        var value = event.target.value;
        this.state.user[field] = value;
        return this.setState({user: this.state.user});
    },

    userFormIsValid: function() {
        var formIsValid = true;
        this.state.errors = {}; // clear any previous errors

        if(this.state.user.firstName.length < 3){
            this.state.errors.firstName = "First name must be at least 3 characters.";
            formIsValid = false;
        }

        if(this.state.user.lastName.length < 3){
            this.state.errors.lastName = "Last name must be at least 3 characters.";
            formIsValid = false;
        }

        if(this.state.user.login.length < 3){
            this.state.errors.login = "Last name must be at least 3 characters.";
            formIsValid = false;
        }

        if(this.state.user.password.length < 3){
            this.state.errors.password = "Last name must be at least 3 characters.";
            formIsValid = false;
        }

        this.setState({errors: this.state.errors});
        return formIsValid;
    },

    saveUser: function(event) {
        event.preventDefault();

        if(!this.userFormIsValid()) {
            return;
        }

        if (this.state.user.id) {
            UserActions.updateUser(this.state.user);
        } else {
            UserActions.createUser(this.state.user);
        }

        this.setState({dirty: false});
        toastr.success("User saved.");
        this.transitionTo("users");
    },

    render: function() {
        return (
            <UserForm
                user={this.state.user}
                onChange={this.setUserState}
                onSave={this.saveUser}
                errors={this.state.errors} />
        );
    }
});

module.exports = ManageUserPage;