import { notification } from "antd";
import { Redirect } from "react-router";
import api from "../axios/api";
class AuthService {
    async login(email, password) {
        const data = {
            "Email": email,
            "Password": password
        }
        try {
            const response = await api.post("/auth/login", data,
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
            if (response.status === 200) {
                console.log(response);
                if (response.data.token) {
                    localStorage.setItem("user", JSON.stringify(response.data.token));
                    window.location = "/profile";
                };
            } else {
                notification.open({ type: "error", message: "Неправильный электронный адрес или пароль!" });
                console.log(response);
            }
        } catch (error) {
            notification.open({ type: "error", message: " Неправильный электронный адрес или пароль! " });
            console.log(error);
        }
    }

    logout() {
        localStorage.removeItem("user");
        window.location = "/login"
    };

    async register(email, login, password) {
        const data = {
            "Email": email,
            "Login": login,
            "Password": password
        }
        try {
            const response = await api.post("/auth/register", data,
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
            if (response.status === 200) {
                console.log(response);
                if (response.data.token) {
                    localStorage.setItem("user", JSON.stringify(response.data.token));
                    notification.open({ type: "success", message: "Вы успешно зарегистрированы ;)" });
                    window.location = "/profile";
                };
            } else {
                notification.open({ type: "error", message: "Что-то пошло не так :(" });
            }
        } catch (error) {
            console.log(error);
            notification.open({ type: "error", message: "Что-то пошло не так :(" });
        }
    }

    isAuth() {
        console.log(1, localStorage.getItem("user"));
        return !!localStorage.getItem("user");
    }
}

export default new AuthService();