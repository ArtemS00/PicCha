import { Form, Input, Button, notification } from 'antd';
import React from 'react';
import { Redirect } from 'react-router';
import api from "../../axios/api";
import './index.scss';
import AuthService from "../../service/Authentication"
function RegisterForm() {

    const onFinish = (values) => {
        AuthService.register(values["электронный адрес"], values["никнейм"], values["пароль"]);
    };

    const validateMessages = {
        types: {
            email: 'Невалидный электронный адрес',
        },
        required: 'Введите ${name}',
        string: {
            range: "Длина должна быть от ${min} до ${max}",
            min: "Минимальная длина ${min} символов"
        }
    };
    if (AuthService.isAuth()) {
        return <Redirect to="/profile" />
    }
    return (
        <div className="registerform">
            <h1 className="registerText">Регистрация</h1>
            <Form className="form"
                validateMessages={validateMessages}
                onFinish={onFinish}>
                <Form.Item
                    name="электронный адрес"
                    rules={[{
                        required: true,
                        type: 'email'
                    }]}>
                    <Input className="input" placeholder="Электронный адрес" />
                </Form.Item>

                <Form.Item
                    name="никнейм"
                    rules={[{ required: true, max: 10, min: 3 }]}
                >
                    <Input className="input" placeholder="Никнейм" />
                </Form.Item>

                <Form.Item
                    name="пароль"
                    dependencies={["пароль2"]}
                    rules={[{
                        required: true,
                        min: 8
                    }
                    ]}>
                    <Input.Password className="input" placeholder="Пароль" />
                </Form.Item>

                <Form.Item
                    name="пароль2"
                    rules={[
                        ({ getFieldValue }) => ({
                            validator(rule, value) {
                                if (getFieldValue("пароль") !== value) {
                                    return Promise.reject(["Пароли должны совпадать"]);
                                }
                                return Promise.resolve();
                            }
                        })
                    ]}
                    dependencies={["пароль"]}
                >
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