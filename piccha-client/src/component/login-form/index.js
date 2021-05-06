import { Form, Input, Button, notification } from 'antd';
import React from 'react';
import './index.scss';
import api from "../../axios/api";
function LoginForm() {

    const onFinish = (values) => {
        const { email, password } = values;
        api.post("/auth", {
            email: email,
            password: password
        })
            .then((response) => {
                if (response.status === 200) {
                    notification.open({ type: "success", message: "Вы успешно вошли ;)" });
                } else {
                    notification.open({ type: "error", message: "Неправильный электронный адрес или пароль!" })
                }
            }).catch(() => notification.open({ type: "error", message: "Неправильный электронный адрес или пароль!" }))
    };

    const validateMessages = {
        types: {
            email: 'Невалидный электронный адрес',
            required: 'Ведите электронный адрес'
        }
    };

    return (
        <div className="loginforml">
            <h1 className="loginText">Вход</h1>
            <Form className="form" validateMessages={validateMessages} onFinish={onFinish}>
                <Form.Item
                    name="email"
                    rules={[{ required: true, type: 'email' }]}
                >
                    <Input className="input" placeholder="Электронный адрес" />
                </Form.Item>
                <Form.Item
                    name="password"
                    rules={[{ required: true, message: 'Придумайте пароль' }]}>
                    <Input.Password className="input" placeholder="Пароль" />
                </Form.Item>
                <Button type="primary" htmlType="submit" className="btn">
                    <h2 className="btnText">Войти</h2>
                </Button>
            </Form>
        </div>
    )
}

export default LoginForm;