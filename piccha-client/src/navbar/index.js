import React from "react";
import { Layout, Menu, PageHeader } from "antd";
import 'antd/dist/antd.css';
import './index.scss';
import MenuItem from "antd/lib/menu/MenuItem";
import { ReactComponent as LogoutIcon } from './logout.svg';
import { ReactComponent as ProfileIcon } from './profile.svg';
import AuthService from "../service/Authentication";
import { Link, Redirect } from "react-router-dom";
import decode from "jwt-decode";
function Navbar() {
    const logout = () => {
        AuthService.logout();
        <Redirect to="/login" />
    }

    return (<>
        <Menu mode="horizontal" className="navBar">
            <Menu.Item className="logoItem">
                <Link to="/">
                    <h1 className="logo">PicCha</h1>
                </Link>
            </Menu.Item>
            {AuthService.isAuth() ?
                <>
                    <MenuItem className="profile">
                        <Link to={`/user/${JSON.parse(decode(localStorage.getItem("user")).userInfo).UserID}`}>
                            <ProfileIcon className="profileIcon" />
                        </Link>
                    </MenuItem>
                    <MenuItem className="logout">
                        <LogoutIcon className="logoutIcon" onClick={logout} />
                    </MenuItem>
                </>
                : <>
                    <MenuItem className="login">
                        <Link to="/login">
                            <h2 className="log">Войти</h2>
                        </Link>
                    </MenuItem>
                    <MenuItem className="register">
                        <Link to="/register">
                            <h2 className="log">Регистрация</h2>
                        </Link>
                    </MenuItem>
                </>}
        </Menu>
    </>
    )
}

export default Navbar;