import React, { useState, useEffect } from 'react';
import { Card, Row, Col, Divider } from 'antd';
import './index.scss';
import Like from '../like';
import Subscribe from '../subscribe-to-challenge'
import ProfilePhoto from '../profile-photo';
import AuthService from "../../service/Authentication";
import Works from '../challengeWorks';
import { DeleteOutlined } from '@ant-design/icons';
import decode from 'jwt-decode';
import Challenges from '../../service/Challenges';
import PostModal from '../add-post-modal';
const { Meta } = Card;

function Challenge(props) {
    const [viewPost, setViewPost] = useState(false);
    const [isLoaded, setIsLoaded] = useState(false);
    const [myId, setMyId] = useState(0);
    useEffect(() => {
        const token = localStorage.getItem("user");
        setMyId(JSON.parse(decode(token).userInfo).UserID);
        setIsLoaded(true);
    });

    const openPost = () => {
        setViewPost(!viewPost);
    };

    const remove = (id) => {
        Challenges.deleteChallenge(props.props.challengeID);
    }
    if (!isLoaded) {
        return (<div className="post">Загрузка...</div>)
    } else {
        return (
            <div className="challengeDiv">
                <Row>

                    <Col span={20}>
                        <Row>
                            <Col span={24}>
                                <Meta className="challenge"
                                    title={<div className="title">
                                        <h2 className="challengeName">{props.props.challengeName}</h2>
                                        {/* <h2 className="deadline">{challenge.createDate}-{challenge.deadline}</h2> */}
                                    </ div>}
                                    description={<h2 className="challengeText">{props.props.challengeDescription}</h2>} />
                            </Col>
                            <>
                                <Col span={7} className="shareCol">
                                    {(!viewPost) ?
                                        <h2 className="see" onClick={openPost}>Посмотреть работы</h2> :
                                        <h2 className="see" onClick={openPost}>Скрыть работы</h2>
                                    }
                                </Col>
                                {AuthService.isAuth() ?
                                    <>
                                        <Col span={6}>
                                            <PostModal challengeID={props.props.challengeID} />
                                        </Col>
                                        <Col span={5} offset={1}>
                                            <Subscribe />
                                        </Col>
                                        <Col span={4} > <Like
                                            likesCount={props.props.likesCount}
                                            liked={props.props.liked}
                                            id={props.props.challengeID}
                                            isChallenge={true} /></Col>
                                    </> :
                                    <>
                                        <Col span={3} offset={13}> <Like
                                            likesCount={props.props.likesCount}
                                            liked={props.props.liked}
                                            challengeID={props.props.challengeID} />
                                        </Col>
                                    </>
                                }
                            </>
                        </Row>
                    </Col>
                    {(props.props.creator.userID === myId) ?
                        <>
                            <Col span={3}>
                                <ProfilePhoto
                                    name={props.props.creator.login}
                                    id={props.props.creator.userID} />
                            </Col>
                            <Col span={1}>
                                <DeleteOutlined
                                    style={{
                                        fontSize: '30px',
                                        marginTop: '10px'
                                    }}
                                    onClick={remove} />
                            </Col>
                        </> :
                        <>
                            <Col span={4}>
                                <ProfilePhoto
                                    name={props.props.creator.login}
                                    id={props.props.creator.userID} />
                            </Col>
                        </>}
                </Row>
                <Divider className="deadline-divider" />
                {/* <h2 className="deadline">{challenge.createDate}-{challenge.deadline}</h2> */}
                {
                    viewPost ?
                        <Works id={props.props.challengeID} /> : null
                }

            </div >
        )
    }
}
export default Challenge