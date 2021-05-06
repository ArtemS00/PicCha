import { Form, Input, Button, Upload, message } from 'antd';
import { UploadOutlined } from '@ant-design/icons';
import React, { useState } from 'react';
import './index.scss';
import 'moment/locale/ru';

function getBase64(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}

function beforeUpload(file) {
    const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
    if (!isJpgOrPng) {
        message.error('You can only upload JPG/PNG file!');
    }
    const isLt2M = file.size / 1024 / 1024 < 2;
    if (!isLt2M) {
        message.error('Image must smaller than 2MB!');
    }
    return isJpgOrPng && isLt2M;
}

function PostForm() {

    const { TextArea } = Input;
    const { Dragger } = Upload;
    const [img, setImg] = useState({
        previewVisible: false,
        previewImage: '',
        previewTitle: '',
    });

    const handlePreview = async file => {
        if (!file.url && !file.preview) {
            file.preview = await getBase64(file.originFileObj);
        }

        setImg({
            previewImage: file.url || file.preview,
            previewVisible: true,
            previewTitle: file.name || file.url.substring(file.url.lastIndexOf('/') + 1),
        });
    };

    const handleChange = ({ file }) => setImg({ previewImage: file });

    return (
        <>
            <h1 className="challengeText">Добавить работу</h1>
            <Form className="form">
                <Form.Item>
                    <Dragger action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                        listType="picture-card"
                        fileList={img.fileList}
                        onPreview={handlePreview}
                        onChange={handleChange}
                        maxCount={1}>
                        Загрузить  <UploadOutlined />
                    </Dragger>
                </Form.Item>
                <Form.Item className="commentItem">
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