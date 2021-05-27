import { Form, Input, Button, notification } from 'antd';
import React, { useEffect } from 'react';
import './index.scss';
import AuthService from "../../service/Authentication";
import { Redirect } from 'react-router';
function LoginForm(props) {
    const onFinish = (values) => {
        AuthService.login(values.email, values.password);
    };
    const validateMessages = {
        types: {
            email: 'Невалидный электронный адрес',
            required: 'Ведите электронный адрес'
        }
    };
    if (AuthService.isAuth()) {
        return <Redirect to="/profile" />;
    }
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