import { Col, Row, Affix } from 'antd';
import React from 'react';
import Challenges from '../../component/challenges';
import LeftBar from '../../component/left-bar';
import "./index.scss";
function MainPage() {
    return (
        <Row className="main">
             <Col span={16} offset={2} className="challenges">
                <Challenges />
            </Col>
            <Col span={6} className="bar2">
                <Affix offsetTop={15}>
                    <LeftBar />
                </Affix>
            </Col>
        </Row>
    )
}

export default MainPage;