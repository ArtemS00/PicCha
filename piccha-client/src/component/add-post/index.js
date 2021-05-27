import { Form, Input, Button, Upload, message } from 'antd';
import { UploadOutlined } from '@ant-design/icons';
import React, { useState } from 'react';
import './index.scss';
import 'moment/locale/ru';
import ChallengesService from '../../service/Challenges';
function PostForm(props) {

    const { TextArea } = Input;
    const { Dragger } = Upload;
    const [img, setImg] = useState('');

    const [comment, setComment] = useState('');

    function getBase64(img) {
        const reader = new FileReader();
        reader.readAsDataURL(img);

        reader.onload = function () {
            const res = reader.result.replace("data:image/png;base64,", "");
            setImg(res);
        }
    }

    const handleChange = info => {
        if (info.file.status === 'uploading') {
            return;
        }
        if (info.file.status === 'done') {
            getBase64(info.file.originFileObj)
        }
    };

    const onFinish = (values) => {
        const imgbyte = img.replace("data:image/png;base64,", "");
        ChallengesService.createChallengeWork(props.challengeID, values.comment, imgbyte);
    };

    return (
        <>
            <h1 className="challengeText">Добавить работу</h1>
            <Form className="form" onFinish={onFinish}>
                <Form.Item
                    name="img"
                    values={img.imageUrl}
                    rules={[{ required: true, message: 'Загрузите изображение' }]}>
                    <Dragger
                        action="https://cors-anywhere.herokuapp.com/https://www.mocky.io/v2/5cc8019d300000980a055e76"
                        listType="picture-card"
                        maxCount={1}
                        onChange={handleChange}>
                        Загрузить  <UploadOutlined />
                    </Dragger>
                </Form.Item>
                <Form.Item
                    name="comment"
                    className="commentItem">
                    <TextArea rows={4} className="descriptionInput" placeholder="Комментарий" />
                </Form.Item>
                <Button type="primary" htmlType="submit" className="btn">
                    <h2 className="btnText">Добавить</h2>
                </Button>
            </Form>
        </>
    )
}

export default PostForm;