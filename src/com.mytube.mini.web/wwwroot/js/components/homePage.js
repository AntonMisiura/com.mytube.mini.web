"use strict";

var React = require("react");

var Home = React.createClass({
    render: function() {
        return (
            <div className="jumbotron">
                <h1>Mircotube</h1>
                <p>This is react, react router, and flux</p>
            </div>
        );
    }
});

module.exports = Home;