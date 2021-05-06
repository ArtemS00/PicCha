import { Form, Input, Button, notification } from 'antd';
import React from 'react';
import api from "../../axios/api";
import './index.scss';

function RegisterForm() {

    const onFinish = (values) => {
        const { username, email, password } = values;
        const data = {
            "Email": values["электронный адрес"],
            "Login": values["никнейм"],
            "Password": values["пароль"]
        }
        console.log(values);
        console.log(data);
        api.post("/auth/register", data,
            {
                headers: {
                    'Content-Type': 'application/json'
                    // 'Content-Type': 'text/plain',
                }
            })
            .then((response) => {
                console.log(response);
                if (response.status === 200) {
                    notification.open({ type: "success", message: "Вы успешно зарегистрированы ;)" });

                } else {
                    notification.open({ type: "error", message: "Что-то пошло не так :(" })
                }
            }).catch((error) => {
                console.log(error);
                notification.open({ type: "error", message: "Что-то пошло не так :(" })
            });
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