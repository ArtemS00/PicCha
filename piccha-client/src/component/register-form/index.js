import { Form, Input, Button, Checkbox } from 'antd';
import React from 'react';
import './index.scss';

function RegisterForm() {
    const validateMessages = {
        types: {
            email: 'Невалидный электронный адрес'
        },
        required: 'Введите электронный адрес'
    };

    return (
        <div className="formlay">
            <h1 className="registerText">Регистрация</h1>
            <Form className="form" validateMessages={validateMessages}>
                <Form.Item
                    name="email"
                    rules={[{ required: true, type: 'email' }]}
                >
                    <Input className="input" placeholder="Электронный адрес" />
                </Form.Item>
                <Form.Item
                    name="nickname"
                    rules={[{ required: true, message: 'Введите свой ник' }]}
                >
                    <Input className="input" placeholder="Никнейм" />
                </Form.Item>
                <Form.Item
                    name="password"
                    rules={[{ required: true, message: 'Придумайте пароль' }]}>
                    <Input.Password className="input" placeholder="Пароль" />
                </Form.Item>
                <Form.Item
                    name="password2"
                    rules={[{ required: true, message: 'Повторите ваш пароль' }]}>
                    <Input.Password className="input" placeholder="Повторите пароль" />
                </Form.Item>
                <Button type="primary" htmlType="submit" className="btn">
                    <h2 className="btnText">Зарегестрироваться</h2>
                </Button>
            </Form>
        </div>
    )
}

export default RegisterForm;