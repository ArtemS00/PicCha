import React, { useState, useEffect } from "react";
import "./index.scss";
import Challenge from "../../component/challenge";

function ChallengeList(props) {
    const [filteredList, setFilteredList] = useState([]);
    const [challenges, setChallenges] = useState(props.challenges);

    const filterList = (filter) => {
        if (!filter) {
            return [];
        } else {
            return challenges.filter((challenges) => {
                return challenges.challengeName.toLowerCase().includes(filter.toLowerCase())
            });
        }
    };

    useEffect(() => {
        setChallenges(props.challenges);
        setFilteredList(filterList(props.filter));
    }, [props.filter]);

    const challs = filteredList
        .map((challenge) =>
            <div key={challenge.challengeID}
                className="item">
                <Challenge props={challenge} />
            </div>
        );

    return (
        <div className="list">
            {challs.length !== 0 ?
                <>
                    {challs}
                </>
                :
                <div className="notfound">
                    <h2 className="text">Ничего не найдено</h2>
                </div>
            }
        </div>
    );

}
export default ChallengeList;