import React from 'react';
import { Card } from 'antd';
import avatar from './img.png';
import './index.scss';
const { Meta } = Card;

function ProfilePhoto(props) {
    return (
        < Card 
        bordered={false}
        cover={<img className="avatar" 
        src={avatar} />} >
            {/* <Meta className="meta" title={<h2 className="nick">{props.props}</h2>} /> */}
            <Meta className="meta" title={<h2 className="nick">Mynickname</h2>} />
        </ Card>
    )
}

export default ProfilePhoto;