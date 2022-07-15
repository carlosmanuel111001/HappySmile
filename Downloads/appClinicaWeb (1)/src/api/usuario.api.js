import { API_URL } from "./config";
const API_PATH = `${API_URL}/usuario`;
const AUTH_API_PATH = `${API_URL}/auth`;

export const GetUsuarios = (token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(API_PATH, {
            headers
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const GetUsuarioById = (usuarioId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${usuarioId}`, {
            headers
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const Login = (usuario) => {
    const raw = JSON.stringify(usuario);
    const request = new Promise((resolve, reject) => {
        fetch(`${AUTH_API_PATH}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: raw,
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const CrearUsuario = (usuario, token) => {
    const raw = JSON.stringify(usuario);

    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(API_PATH, {
            method: 'POST',
            headers: headers,
            body: raw,
            redirect: 'follow',
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const EliminarUsuario = (usuarioId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${usuarioId}`, {
            method: 'DELETE',
            headers: headers,
            redirect: 'follow',
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};