import { notification } from "antd";
import { Redirect } from "react-router";
import api from "../axios/api";

class ChallengesService {

    createChallenge(data) {
        const user = JSON.parse(localStorage.getItem('user'));
        const config = {
            headers: {
                'Authorization': 'Bearer ' + user
            }
        };

        api.post("/challenge/createChallenge", data, config)
            .then((response) => {
                if (response.status === 200) {
                    notification.open({ type: "success", message: "Вы добавили челлендж;)" });
                } else {
                    notification.open({ type: "error", message: "Что-то пошло не так :(" })
                }
            }).catch((error) => {
                console.log(error);
                notification.open({ type: "error", message: "Что-то пошло не так :(" })
            });
    }

    async getAllChallenges() {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/getchallenges"
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            }
        }
        const resp = await api.get(apiUrl, config);
        return resp.data;
    }
    async getChallengeWorks(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            },
            params: {
                "challengeID": id
            }
        }
        const apiUrl = "/challenge/getChallengeWorks"
        const resp = await api.get(apiUrl, config);
        console.log(4, resp.data);
        return resp.data;
    }
    // getMyChallenges() {
    //     const apiUrl = "/challenge/getchallenges"
    //     api.get(apiUrl).then((resp) => 
    //     )
    // }

    like(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/likeChallenge"
        const config = {
            headers: {
                'Authorization': 'Bearer ' + user
            }
        }
        var formData = new FormData();
        formData.append("challengeID", id)
        api.post(apiUrl, formData, config);
        return true;
    }

    unlike(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/unlikeChallenge"
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            }
        }
        var formData = new FormData();
        formData.append("challengeID", id)
        api.post(apiUrl, formData, config);
        return;
    }

    createChallengeWork(id, comment, work) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/createChallengeWork"
        const config = {
            headers: {
                'Authorization': 'Bearer ' + user
            }
        }
        var formData = new FormData();
        formData.append("challengeID", id);
        formData.append("comment", comment);
        formData.append("work", work);
        api.post(apiUrl, formData, config)
            .then((response) => {
                if (response.status === 200) {
                    notification.open({ type: "success", message: "Вы добавили работу;)" });

                } else {
                    notification.open({ type: "error", message: "Что-то пошло не так :(" })
                }
            }).catch((error) => {
                console.log(error);
                notification.open({ type: "error", message: "Что-то пошло не так :(" })
            });
    }

    likeWork(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/likeChallengeWork"
        const config = {
            headers: {
                'Authorization': 'Bearer ' + user
            }
        }
        console.log("aa");
        var formData = new FormData();
        formData.append("challengeID", id)
        api.post(apiUrl, formData, config);
        return true;
    }

    unlikeWork(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/unlikeChallengeWork"
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            }
        }
        var formData = new FormData();
        formData.append("challengeID", id)
        api.post(apiUrl, formData, config);
        return;
    }
}

export default new ChallengesService();