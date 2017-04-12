/*
 * Copyright (c) 2015, Facebook, Inc.
 * All rights reserved.
 *
 * AppDispatcher
 *
 * A singleton that operates as the central hub for application updates.
 */

var Dispatcher = require("flux").Dispatcher;

module.exports = new Dispatcher();

