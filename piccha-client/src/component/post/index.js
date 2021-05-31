import React from 'react';
import { Card, Col, Divider, Row } from 'antd';
import './index.scss'
import avatar from '../profile-photo/img.png';
import picture from './picture.jpg';
import Like from '../like';
import { Link } from 'react-router-dom';
const { Meta } = Card;

function Post(props) {
    return (
        <Row className="post">
            <Col span={24}>
                <Card bordered={false}
                    cover={<img src={"data:image/png;base64," + props.work.work} className="picture" />}>
                </Card>
            </Col>
            <Col span={20}>
                <Link to={`user/${props.work.authorID}`}>
                    <Meta className="postMeta"
                        avatar={<img className="postAvatar" src={avatar} />}
                        title={<h2 className="name">{props.work.authorLogin}</h2>}
                        description={<h2 className="postText">{props.work.comment}</h2>} />
                </Link>
            </Col>
            <Col span={4} className="postLike"><Like
                id={props.work.challengeWorkID}
                likesCount={props.work.likesCount}
                liked={props.work.liked}
            />
            </Col>
        </Row>
    )
}

export default Post;