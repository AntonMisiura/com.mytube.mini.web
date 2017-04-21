"use strict";

var React = require("react");
var Router = require("react-router");
var Link = Router.Link;
var UserActions = require("../../actions/userActions");
var toastr = require("toastr");

var UserList = React.createClass({
    propTypes: {
        users: React.PropTypes.array.isRequired
    },

    deleteUser: function(id, event) {
        event.preventDefault();
        UserActions.deleteUser(id);
        toastr.success("User Deleted");
    },

    render: function () {
        var createUserRow = function(user){
            return (
                    <tr key={user.id}>
                        <td><a href="#" onClick={this.deleteUser.bind(this, user.id)}>Delete</a></td>
                        <td>{user.firstName} {user.lastName}</td>
                    </tr>
            );
    };

return (
    <div>
        <table className="table">
            <thread>
                <th></th>
                <th>Name</th>
            </thread>
            <tbody>
                {this.props.users.map(createUserRow, this)}
            </tbody>
        </table>
    </div>
        );
}
});

module.exports = UserList;