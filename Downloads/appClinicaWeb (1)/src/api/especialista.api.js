import { API_URL } from "./config";
const API_PATH = `${API_URL}/especialista`;

export const GetEspecialistas = (token) => {
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

export const GetEspecialistaById = (especialistaId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${especialistaId}`, {
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

export const CrearEspecialista = (especialista, token) => {
    const raw = JSON.stringify(especialista);
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
            if(data.error) {
                reject(data.error);
            }
            else {
                resolve(data);
            }
        })
        .catch(error => reject(error));
    });
    return request;
};

export const GetUsuariosEspecialistas = (token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/posiblesUsuarios`, {
            headers
        })
        .then(res => res.json())
        .then(data => {
            if(data.error) {
                reject(data.error);
            }
            else {
                resolve(data);
            }
        })
        .catch(error => reject(error));
    });
    return request;
};

export const EliminarEspecialista = (especialistaId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${especialistaId}`, {
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