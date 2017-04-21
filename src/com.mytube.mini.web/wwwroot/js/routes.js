"use strict";

var React = require("react");

var Router = require("react-router");
var DefaultRoute = Router.DefaultRoute;
var Route = Router.Route;
var NotFoundRoute = Router.NotFoundRoute;
var Redirect = Router.Redirect;

var routes = (
  <Route name="app" path="/" handler={require("./components/app")}>
    <DefaultRoute handler={require("./components/homePage")} />
    <Route name="users" handler={require("./components/users/userPage")} />
    <Route name="addUser" path="user" handler={require("./components/users/manageUserPage")} />
    <Route name="manageUser" path="user/:id" handler={require("./components/users/manageUserPage")} />

    <Route name="about" handler={require("./components/about/aboutPage")} />
    <NotFoundRoute handler={require("./components/notFoundPage")} />

    <Redirect from="about-us" to="about" />
    <Redirect from="user" to="users" />
  </Route>
);

module.exports = routes;