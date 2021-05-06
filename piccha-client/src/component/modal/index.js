import React, { useState } from 'react';
import { Modal, Button } from 'antd';
import './index.scss'

function ModalWin(props) {
    const [isModalVisible, setIsModalVisible] = useState(false);

    const showModal = () => {
        setIsModalVisible(true);
    };

    const handleOk = () => {
        setIsModalVisible(false);
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };
    return (
        <>
            {props.open === "Добавить работу" ?
                <Button onClick={showModal} className='postbtn'>
                    <h2 className="btnText" onClick={showModal}>{props.open}</h2>
                </Button>
                : <h2 className="challText" onClick={showModal}>{props.open}</h2>
            }
            {/* <Button onClick={showModal} className={props.open === "Добавить работу" ? 'postbtn' : 'challbtn'} >
                <h2 className="btnText" onClick={showModal}>{props.open}</h2>
            </Button> */}
            <Modal className="formlay"
                visible={isModalVisible}
                onOk={handleOk}
                onCancel={handleCancel}
                footer={null}>
                {props.children}
            </Modal>
        </>)
}

export default ModalWin;
