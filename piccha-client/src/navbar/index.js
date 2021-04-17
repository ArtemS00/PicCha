import React from "react";
import { Layout, Menu, PageHeader } from "antd";
import 'antd/dist/antd.css';
import './index.scss';
const { Header } = Layout;
function Navbar() {
    return (<>
        <Menu mode="horizontal" className="navBar">
            <Menu.Item className="logoItem">
                <h1 className="logo">PicCha</h1>
            </Menu.Item>
            <Menu.Item className="searchItem">
               <input className="search"placeholder="Поиск"></input>
            </Menu.Item>
        </Menu>

    </>
    )

}

export default Navbar;