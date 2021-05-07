import { Col, Row, Affix } from 'antd';
import React from 'react';
import Challenges from '../../component/challenges';
import LeftBar from '../../component/left-bar';
import "./index.scss";
import AuthService from "../../service/Authentication";
function MainPage() {
    return (
        <Row className="main">
            { AuthService.isAuth() ?
                <>
                    <Col span={16} offset={2} className="challenges">
                        <Challenges />
                    </Col>
                    <Col span={6} className="bar2">
                        <Affix offsetTop={15}>
                            <LeftBar />
                        </Affix>
                    </Col>
                </>
                :
                <>
                    <Col span={20} offset={4} className="challenges">
                        <Challenges />
                    </Col>
                </>
            }
        </Row>
    )
}

export default MainPage;