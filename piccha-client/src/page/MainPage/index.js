import { Col, Row, Affix, Input } from 'antd';
import React, { useState, useEffect, useRef } from 'react';
import Challenges from '../../component/challenges';
import LeftBar from '../../component/left-bar';
import "./index.scss";
import AuthService from "../../service/Authentication";
import ChallengesService from "../../service/Challenges";
import ChallengeList from '../../component/serach-challenge-list';

function MainPage() {
    const [searchString, setSearchString] = useState('');
    const [challenges, setChallenges] = useState();
    const inputRef = useRef(null);
    const [isLoaded, setIsLoaded] = useState(false);

    useEffect(() => {
        async function getPosts() {
            if (AuthService.isAuth()) {
                setChallenges(await ChallengesService.getAllChallenges());
            }
            else {
                setChallenges(await ChallengesService.getChallengesForGuest());
            }
            setIsLoaded(true);
        }
        getPosts();
    }, []);


    const onChangeSearch = e => {
        const { value } = e.target;
        setSearchString(value);
    };

    return (
        <>
            <Row className="main">
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
                {searchString.length === 0 ?
                    <>
                        {AuthService.isAuth() ?
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
                    </> :
                    <>
                        <Col span={16} offset={2} className="challenges">
                            <ChallengeList filter={searchString} challenges={challenges} />
                        </Col>
                        <Col span={6} className="bar2">
                            <Affix offsetTop={15}>
                                <LeftBar />
                            </Affix>
                        </Col>
                    </>
                }
            </Row>
        </>
    )
}

export default MainPage;