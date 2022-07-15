import { API_URL } from "./config";
const API_PATH = `${API_URL}/diagnostico`;

export const GetDiagnosticos = (token) => {
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

export const CrearDiagnostico = (diagnostico, token) => {
    const raw = JSON.stringify(diagnostico);

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

export const EliminarDiagnostico = (citaId, especialistaId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/?citaId=${citaId}&especialistaId=${especialistaId}`, {
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