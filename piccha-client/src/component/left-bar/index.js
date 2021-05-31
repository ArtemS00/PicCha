import React from "react";
import "./index.scss";
import { Link } from "react-router-dom";
import { Divider } from "antd";
import ChallengeModal from "../challengeModal";
function LeftBar() {
    return (
        <div className="bar">
            <div>
                <h1 className="barText">Главная</h1>
                <Divider />
                <h1 className="barText">Моя лента</h1>
                <Divider />
            </div>
            <ChallengeModal />
            <Divider />
        </div>
    )
}
export default LeftBar;