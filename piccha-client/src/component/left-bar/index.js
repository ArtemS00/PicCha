import React from "react";
import "./index.scss";
import ModalWin from "../modal";
import ChallengeForm from "../add-challenge";
import { Link } from "react-router-dom";
import { Divider } from "antd";
function LeftBar() {
    return (
        <div className="bar">
            <div>
                <h1 className="barText">Главная</h1>
                <Divider />
                <h1 className="barText">Моя лента</h1>
                <Divider />
            </div>
            < ModalWin open={"Добавить челлендж"}>
                <ChallengeForm />
            </ModalWin>
            <Divider />
        </div>
    )
}
export default LeftBar;