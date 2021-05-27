import { Form, Input, Button, DatePicker, notification } from 'antd';
import React, { useState } from 'react';
import './index.scss';
import 'moment/locale/ru';
import locale from 'antd/es/date-picker/locale/ru_RU';
import ChallengesService from '../../service/Challenges';
function ChallengeForm() {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const { TextArea } = Input;

    const onFinish = (values) => {
        const data = {
            "ChallengeName": values["name"],
            "ChallengeDescription": values["description"]
        }
        ChallengesService.createChallenge(data);
        setIsModalVisible(false);

    };
    return (
        <>
            <h1 className="challengeText">Создать челлендж</h1>
            <Form className="form" onFinish={onFinish}>
                <Form.Item name="name">
                    <Input className="input" placeholder="Название" />
                </Form.Item>
                <Form.Item name="description">
                    <TextArea rows={4} className="descriptionInput" placeholder="Описание" />
                </Form.Item>
                <Form.Item>
                    <DatePicker className="dateInput" placeholder="Дедлайн" format={'DD/MM/YYYY'} locale={locale} />
                </Form.Item>
                <Button type="primary" htmlType="submit" className="btn">
                    <h2 className="btnText">Добавить</h2>
                </Button>
            </Form>
        </>
    )
}

export default ChallengeForm;