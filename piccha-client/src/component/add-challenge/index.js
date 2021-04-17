import { Form, Input, Button, DatePicker} from 'antd';
import React from 'react';
import './index.scss';
import 'moment/locale/ru';
import locale from 'antd/es/date-picker/locale/ru_RU';

function ChallengeForm() {
    const { TextArea } = Input;
    return (
        <div className="formlay">
            <h1 className="challengeText">Создать челлендж</h1>
            <Form className="form">
                <Form.Item >
                    <Input className="input" placeholder="Название" />
                </Form.Item>
                <Form.Item>
                    <TextArea rows={4}  className="descriptionInput" placeholder="Описание"/>
                </Form.Item>
                <Form.Item>
                <DatePicker className="dateInput" placeholder="Дедлайн" format={'DD/MM/YYYY'} locale={locale}/>
                </Form.Item>
                <Button type="primary" htmlType="submit" className="btn">
                    <h2 className="btnText">Добавить</h2>
                </Button>
            </Form>
        </div>
    )
}

export default ChallengeForm;