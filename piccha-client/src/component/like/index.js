import React, { useState, useEffect } from 'react'
import { ReactComponent as LikeIcon } from './svg/like.svg';
import { ReactComponent as NoLikeIcon } from './svg/nolike.svg';
import AuthService from "../../service/Authentication";
import ChallengesService from "../../service/Challenges";
import './index.scss'
import { Col, message, notification, Row } from 'antd';
function Like(props) {
    const [like, setLike] = useState();
    const [isLoaded, setIsLoaded] = useState(false);
    useEffect(() => {
        setLike({
            count: props.likesCount,
            isLiked: props.liked,
        });
        setIsLoaded(true);
    }, [setLike]);


    const toLike = (e) => {
        if (AuthService.isAuth()) {
            if (props.isChallenge === true) {
                if (!like.isLiked) {
                    ChallengesService.like(props.id);
                } else {
                    ChallengesService.unlike(props.id);
                }
            } else {
                if (!like.isLiked) {
                    ChallengesService.likeWork(props.id);
                } else {
                    ChallengesService.unlikeWork(props.id);
                }
            }
            const count = like.isLiked ? --like.count : ++like.count
            const isLiked = !like.isLiked;
            setLike({ count: count, isLiked: isLiked });
        }
        else {
            notification.open({ message: "Необходимо войти в аккаунт" });
        }
    };
    if (!isLoaded) {
        return (<div><h1>...</h1></div>)
    } else {
        return (<Row>
            <Col span={16}>
                {(like.isLiked) ?
                    <LikeIcon className="like" onClick={toLike} /> :
                    <NoLikeIcon className="like" onClick={toLike} />
                }
            </Col>
            <Col span={8}>
                <h2 className="likeCount">{like.count}</h2>
            </Col>
        </Row>)
    }
}

export default Like;