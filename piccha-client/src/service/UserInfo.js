import { notification } from "antd";
import api from "../axios/api";

class UserService {
    // async getAllChallenges() {
    //     const user = JSON.parse(localStorage.getItem('user'));
    //     const apiUrl = "/challenge/getchallenges"
    //     const config = {
    //         headers: {
    //             'Content-Type': 'application/json',
    //             'Authorization': 'Bearer ' + user
    //         }
    //     }
    //     const resp = await api.get(apiUrl, config);
    //     console.log(resp.data);
    //     return resp.data;
    // }

    async GetUserInfo(id) {
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/user/getUserInfo";
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            }
        }
        const resp = await api.get(apiUrl + "?userID=" + id, config);
        return resp.data;
    }

    async GetUserChallenges(id) {
        console.log(88, id);
        const user = JSON.parse(localStorage.getItem('user'));
        const apiUrl = "/challenge/getUserChallenges";
        const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + user
            }
        }
        const resp = await api.get(apiUrl + "?userID=" + id, config);
        return resp.data;
    }
}

const user = {
    username: "Aida",
    challengesCount: 22,
    worksCount: 10,
    challenges: [
        {
            challengeDescription: "test2",
            challengeID: 2,
            challengeName: "test2",
            creator: {
                email: "test@test.com",
                image: "",
                login: "test",
                password: null,
                role: 1,
                userID: 2
            },
            liked: true,
            likesCount: 2,
            participated: false,
            participationsCount: 0,
        }
    ],
    works: [
        {
            challengeDescription: "test3",
            challengeID: 2,
            challengeName: "test2",
            creator: {
                email: "test@test.com",
                image: "",
                login: "test",
                password: null,
                role: 1,
                userID: 2
            },
            liked: true,
            likesCount: 2,
            participated: false,
            participationsCount: 0,
        }
    ]
}
export default new UserService();