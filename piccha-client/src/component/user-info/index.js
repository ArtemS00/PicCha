import React from 'react';
import { Card } from 'antd';
import avatar from '../profile-photo/img.png';
import './index.scss';
function UserInfo() {
    return (
        <div className="userInfo">
            <Card bordered={false}
                cover={<img src={avatar} className="userPhoto" />}></Card>
        </div>
    )
}

export default UserInfo;