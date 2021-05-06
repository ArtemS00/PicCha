import { Form, Input, Button, DatePicker, notification } from 'antd';
import React from 'react';
import './index.scss';
import 'moment/locale/ru';
import locale from 'antd/es/date-picker/locale/ru_RU';
import api from "../../axios/api";
function ChallengeForm() {
    const { TextArea } = Input;
   
    const onFinish = (values) => {
        console.log(values);
        const data = {
            "CreatorID": 2,
            "ChallangeName": values["name"],
            "ChallengeDescription": values["description"]
        }
        api.post("/challenge/createCHallenge", data,
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then((response) => {
                console.log(response);
                if (response.status === 200) {
                    notification.open({ type: "success", message: "Вы добавили челлендж;)" });

                } else {
                    notification.open({ type: "error", message: "Что-то пошло не так :(" })
                }
            }).catch((error) => {
                console.log(error);
                notification.open({ type: "error", message: "Что-то пошло не так :(" })
            });
    };
    return (
        <>
            <h1 className="challengeText">Создать челлендж</h1>
            <Form className="form" onFinish={onFinish}>
                <Form.Item name="name">
                    <Input className="input" placeholder="Название"/>
                </Form.Item>
                <Form.Item name="description">
                    <TextArea rows={4} className="descriptionInput" placeholder="Описание"/>
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