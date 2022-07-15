import { API_URL } from "./config";
const API_PATH = `${API_URL}/cita`;

export const GetCitas = (token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(API_PATH, {
            headers: headers,
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const GetCitaById = (citaId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${citaId}`, {
            headers: headers,
        })
        .then(res => res.json())
        .then(data => {
            resolve(data);
        })
        .catch(error => reject(error));
    });
    return request;
};

export const CrearCita = (cita, token) => {
    const raw = JSON.stringify(cita);
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

export const EliminarCita = (citaId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${citaId}`, {
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