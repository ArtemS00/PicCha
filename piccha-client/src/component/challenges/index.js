import React, { useEffect, useState } from 'react';
import ChallengeForm from '../add-challenge';
import PostForm from '../add-post';
import Challenge from '../challenge';
import './index.scss';
import api from '../../axios/api';
import ModalWin from '../modal';

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
        // const apiUrl = "/challenge/getchallenges"
        // api.get(apiUrl).then((resp) => {
        //     const posts = resp.data;
        //     setPosts(posts);
        //     setIsLoad(true);
        // });
        setIsLoad(true);
    });
    if (isLoad) {
        // const postItems = posts.map((post) =>
        //     <Challenge props={post} key={post.challengeID} />
        // );
        return (
            <>
                {/* <div className="challenges">
                    {postItems}
                </div> */}
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
                <Challenge props={props} />
            </>)
    }
    else {
        return (<div className="challenges"></div>)
    }
}

export default Challenges