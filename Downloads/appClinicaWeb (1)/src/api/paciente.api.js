import { API_URL } from "./config";
const API_PATH = `${API_URL}/paciente`;

export const GetPacientes = (token) => {
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

export const GetPacienteById = (especialistaId, token) => {
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

export const CrearPaciente = (paciente, token) => {
    const raw = JSON.stringify(paciente);
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

export const GetUsuariosPacientes = (token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);

    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/posiblesUsuarios`, {
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

export const EliminarPaciente = (pacienteId, token) => {
    const headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", `Bearer ${token}`);
    
    const request = new Promise((resolve, reject) => {
        fetch(`${API_PATH}/${pacienteId}`, {
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