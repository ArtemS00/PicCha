import React, { useState, useEffect } from 'react'
import './index.scss'
import api from '../../axios/api'
function Subscribe() {
    const [isJoin, setIsJoin] = useState();
    useEffect(() => {
        // const apiUrl = ""
        // api.get(apiUrl).then((resp) => {
        //     const join = resp.data;
        //     setIsJoin(join);
        // });
        setIsJoin(false);
    }, [setIsJoin]);

    const toJoin = () => {
        const join = !isJoin;
        api.post("", { join }).then(() => {
            setIsJoin(join);
        })

        setIsJoin(join);
    };
    return (<>
        {(!isJoin) ?
            <h2 className="join" onClick={toJoin}>Подписаться</h2> :
            <h2 className="nojoin" onClick={toJoin}>Отписаться</h2>
        }
    </>
    )
}
export default Subscribe;