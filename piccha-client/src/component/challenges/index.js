import React, { useEffect, useState } from 'react';
import Challenge from '../challenge';
import './index.scss';
import ChallengesService from "../../service/Challenges";

const props = {
    challengeName: "Challenge",
    challengeDescription: `Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. 
            Velit officia consequat duis enim velit mollit.`,
    createDate: '21.04.2021',
    deadline: '27.04.2021',

    creator: {
        userID: 2
    }
}


function Challenges() {
    const [isLoad, setIsLoad] = useState(false);
    const [posts, setPosts] = useState();
    useEffect(() => {
        async function getPosts() {
            setPosts(await ChallengesService.getAllChallenges());
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