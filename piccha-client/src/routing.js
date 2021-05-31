import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import RegisterPage from './page/RegisterPage';
import LoginPage from './page/LoginPage';
import ProfilePage from './page/ProfilePage';
import MainPage from './page/MainPage';
import Navbar from "./navbar";
import ProfilePhoto from "./component/profile-photo";
const Routing = () => (
    <Router>
        <Navbar />
        <Route path="/" component={MainPage} exact />
        <Route path="/register" component={RegisterPage} exact />
        <Route path="/login" component={LoginPage} exact />
        <Route component={ProfilePage} path="/user/:id" />
    </Router>
);

export default Routing;
