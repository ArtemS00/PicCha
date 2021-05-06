import React from 'react';
import { Card, Col, Divider, Row } from 'antd';
import './index.scss'
import avatar from '../profile-photo/img.png';
import picture from './picture.jpg';
import Like from '../like';
const { Meta } = Card;

function Post() {
    return (
        <Row className="post">
            <Col span={24}>
            </Col>
            <Col span={24}>
                <Card bordered={false}
                    cover={<img src={picture} className="picture" />}>
                </Card>
            </Col>
            <Col span={20}>
                <Meta className="postMeta"
                    avatar={<img className="postAvatar" src={avatar} />}
                    title={<h2 className="name">NickName</h2>}
                    description={<h2 className="postText">Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.</h2>} />

            </Col>
            <Col span={4} className="postLike"><Like /></Col>
        </Row>
    )
}

export default Post;