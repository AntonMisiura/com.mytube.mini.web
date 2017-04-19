"use strict";

var React = require("react");
var Input = require("../common/textInput.js");

var UserForm = React.createClass({
    propTypes: {
        user: React.PropTypes.object.isRequired,
        onSave: React.PropTypes.func.isRequired,
        onChange: React.PropTypes.func.isRequired,
        errors: React.PropTypes.object
    },

    render: function () {
        return (
            <form>
                <h1>Manage User</h1>
                <Input
                    name="firstName"
                    label="First Name"
                    value={this.props.user.firstName}
                    onChange={this.props.onChange}
                    error={this.props.errors.firstName} />

                <Input
                    name="lastName"
                    label="Last Name"
                    value={this.props.user.lastName}
                    onChange={this.props.onChange}
                    error={this.props.errors.lastName} />

                <Input
                    name="login"
                    label="Login"
                    value={this.props.user.login}
                    onChange={this.props.onChange}
                    error={this.props.errors.login} />

                <Input
                    name="password"
                    label="Password"
                    value={this.props.user.password}
                    onChange={this.props.onChange}
                    error={this.props.errors.password} />

                <input type="submit" value="Save" className="btn btn-default" onClick={this.props.onSave} />
            </form>
        );
    }
});

module.exports = UserForm;

