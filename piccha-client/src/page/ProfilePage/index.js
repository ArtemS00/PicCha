import React from 'react';
import './index.scss';
import Modal from '../../component/modal';
import AddChallenge from '../../component/add-challenge';
import AddPost from '../../component/add-post';
import Challenges from '../../component/challenges';
import UserInfo from '../../component/user-info';
import { Col, Row } from 'antd';
import './index.scss';
import AuthService from "../../service/Authentication";
import { Redirect } from 'react-router';
function AddChallengePage() {
    if (AuthService.isAuth()) {
        return (
            <Row className="profile">
                <Col span={6} offset={2}>  <UserInfo /></Col>
                <Col span={12} offset={1}> <Challenges /></Col>
            </Row>
        )
    }
    else {
        return <Redirect to="/" />
    }
}

export default AddChallengePage;