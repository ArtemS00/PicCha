import React, { useState, useEffect } from 'react';
import { Card, Row, Col, Divider } from 'antd';
import './index.scss';
import Like from '../like';
import Subscribe from '../subscribe-to-challenge'
import ProfilePhoto from '../profile-photo';
import Post from '../post';
import ModalWin from '../modal';
import PostForm from '../add-post';
import AuthService from "../../service/Authentication";
const { Meta } = Card;

function Challenge(props) {
    const [challenge, setChallenge] = useState();
    const [viewPost, setViewPost] = useState(false);
    const [isLoaded, setIsLoaded] = useState(false);

    useEffect(() => {
        setIsLoaded(true);
        // setChallenge({
        //     name: "Challenge",
        //     description: `Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. 
        //     Velit officia consequat duis enim velit mollit.`,
        //     createDate: '21.04.2021',
        //     deadline: '27.04.2021'
        // });
        // console.log(props);
    }, [setChallenge]);

    const openPost = () => {
        setViewPost(!viewPost);
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
                                            < ModalWin open={"Добавить работу"} className="addPostText">
                                                <PostForm />
                                            </ModalWin>
                                        </Col>
                                        <Col span={5} offset={1}>
                                            <Subscribe />
                                        </Col>
                                        <Col span={4} > <Like /></Col>
                                    </> :
                                    <>
                                        <Col span={4} offset={12}> <Like /></Col>
                                    </>
                                }
                            </>
                        </Row>
                    </Col>
                    <Col span={4}>
                        <ProfilePhoto props={props.props.creator.userID} />
                    </Col>
                </Row>
                <Divider className="deadline-divider" />
                {/* <h2 className="deadline">{challenge.createDate}-{challenge.deadline}</h2> */}
                {
                    (viewPost) ?
                        <>
                            <Post />
                            {/* <Divider className="divider" /> */}
                            <Post />
                        </> : null

                }
            </div>
        )
    }
}
export default Challenge