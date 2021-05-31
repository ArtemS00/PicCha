import React from 'react';
import { Card } from 'antd';
import avatar from './img.png';
import './index.scss';
import { Link } from 'react-router-dom';
const { Meta } = Card;

function ProfilePhoto(props) {
    console.log(props);
    return (
        <Link to={`user/${props.id}`}>
            <Meta className="meta"
                avatar={<img className="avatar" src={avatar} />}
                title={<h2 className="nick">{props.name}</h2>} />
        </Link>
    )
}

export default ProfilePhoto;