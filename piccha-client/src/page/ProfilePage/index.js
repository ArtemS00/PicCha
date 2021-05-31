import React, { useState, useEffect, useRef } from 'react';
import './index.scss';
import Challenges from '../../component/challenges';
import { Col, Row, Divider, Input } from 'antd';
import './index.scss';
import AuthService from "../../service/Authentication";
import { Redirect } from 'react-router';
import ChallengeModal from '../../component/challengeModal';
import UserService from "../../service/UserInfo";
import Challenge from "../../component/challenge";
function ProfilePage({ match }) {
    const [searchString, setSearchString] = useState('');
    const [userInfo, setUserInfo] = useState();
    const [userChallenges, setUserChallenges] = useState();
    const inputRef = useRef(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [isChallenges, setIsChallenges] = useState(true);

    useEffect(() => {
        const id = match.params.id;
        async function getUserInfo() {
            setUserInfo(await UserService.GetUserInfo(id))
            setUserChallenges(await UserService.GetUserChallenges(id));
            setIsLoaded(true);
        }
        getUserInfo();
    }, []);

    const onChangeSearch = e => {
        const { value } = e.target;
        setSearchString(value);
    };

    const getMyWorks = () => {
        setIsChallenges(false);
    }

    const getMyChallenges = () => {
        setIsChallenges(true);
    }

    if (AuthService.isAuth()) {
        if (isLoaded) {
            const postItems = userChallenges.map((post) =>
                <Challenge props={post} key={post.challengeID} />
            );
            return (
                <Row className="profile">
                    <Col span={22} offset={2}>
                        <h1 className="name">{userInfo.login}</h1>
                    </Col>
                    <Col span={6} offset={2}>
                        <h1 className="count">Количество челленджей: {userInfo.challengesCount - 1}</h1>
                    </Col>
                    <Col span={16} offset={0}>
                        <h1 className="count">Количество работ: {userInfo.worksCount}</h1>
                    </Col>
                    <Col span={22} offset={2}>
                        <div className="search" ref={inputRef}>
                            <div>
                                <Input
                                    onChange={(e) => onChangeSearch(e)}
                                    className="search"
                                    placeholder="Поиск челленджа"
                                    value={searchString}
                                />
                            </div>
                        </div>
                    </Col>
                    <Col span={16} offset={2}>
                        {postItems}
                    </Col>
                    <Col span={6}>
                        <div className="bar">
                            <div>
                                <h1 className="barText" onClick={getMyChallenges}>Мои челленджи</h1>
                                <Divider />
                                <h1 className="barText" onClick={getMyWorks}>Мои работы</h1>
                                <Divider />
                            </div>
                            <ChallengeModal />
                            <Divider />
                        </div>
                    </Col>
                </Row>
            )
        }
        else {
            return (<div>Загрузка...</div>)
        }
    }
    else {
        return <Redirect to="/" />
    }
}

export default ProfilePage;