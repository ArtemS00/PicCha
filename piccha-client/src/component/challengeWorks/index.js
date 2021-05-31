import React, { useEffect, useState } from 'react';
import ChallengesService from '../../service/Challenges';
import Post from '../post';
import "./index.scss";
function Works(props) {
    const [isLoad, setIsLoad] = useState(false);
    const [works, setWorks] = useState();
    useEffect(() => {
        async function getWorks() {
            const res = await ChallengesService.getChallengeWorks(props.id);
            setWorks(res);
            setIsLoad(true);
        }
        getWorks();
        return;
    }, []);

    if (isLoad) {
        const workItems = works.map((work) =>
            <Post work={work} key={work.challengeWorkID} />
        );
        if (workItems.length === 0) {
            return (<><h2 className="text">Работ пока нет</h2></>)
        }
        else {
            return (
                <>
                    <div className="challenges">
                        {workItems}
                    </div>
                </>)
        }
    }
    else {
        return (<div className="challenges"></div>)
    }
}

export default Works;