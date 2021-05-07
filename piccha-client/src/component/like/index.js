import React, { useState, useEffect } from 'react'
import { ReactComponent as LikeIcon } from './svg/like.svg';
import { ReactComponent as NoLikeIcon } from './svg/nolike.svg';
import AuthService from "../../service/Authentication";
import './index.scss'
import { Col, message, notification, Row } from 'antd';
function Like() {
    const [like, setLike] = useState();
    const [isLoaded, setIsLoaded] = useState(false);
    useEffect(() => {
        // const apiUrl = ""
        // api.get(apiUrl).then((resp) => {
        //     const like = resp.data;
        //     setLike(like);
        //     setIsLoaded(true)
        // });
        setIsLoaded(true);
        setLike({
            count: 1004,
            isLiked: false,
        });
    }, [setLike]);

    const toLike = (e) => {
        if (AuthService.isAuth()) {
            const count = like.isLiked ? --like.count : ++like.count
            const isLiked = !like.isLiked;
            // api.post("", {
            //     count: count, isLiked: isLiked
            // }).then(() => {
            //     setlike( {count: count, isLiked: isLiked});
            //     e.target.style.fill = isLiked ? "var(--clr-primary)" : "#EDEDFF";
            // })
            setLike({ count: count, isLiked: isLiked });
        }
        else {
            notification.open({message: "Необходимо войти в аккаунт"});
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