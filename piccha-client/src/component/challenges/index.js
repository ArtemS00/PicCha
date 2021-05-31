import React, { useEffect, useState } from 'react';
import Challenge from '../challenge';
import './index.scss';
import ChallengesService from "../../service/Challenges";
import Authentication from '../../service/Authentication';


function Challenges(props) {
    const [isLoad, setIsLoad] = useState(false);
    const [posts, setPosts] = useState();
    useEffect(() => {
        async function getPosts() {
            if (Authentication.isAuth()) {
                setPosts(await ChallengesService.getAllChallenges());
            }
            else {
                setPosts(await ChallengesService.getChallengesForGuest());
            }
            setIsLoad(true);
        }
        getPosts();
    }, []);

    if (isLoad) {
        const postItems = posts.map((post) =>
            <Challenge props={post} key={post.challengeID} />
        );
        return (
            <>
                <div className="challenges">
                    {postItems}
                </div>
            </>)
    }
    else {
        return (<div className="challenges"></div>)
    }
}

export default Challenges