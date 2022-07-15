import { useState, useContext, useEffect, } from 'react';
import { Navigate } from 'react-router-dom';
import { Login } from '../../api/usuario.api';
import { LoginUI } from '../../componentes/usuario/login';
import { UsuarioContext } from '../../contexts/usuario';
import './../../assets/login.css';

export const LoginContenedor = () => {

    const context = useContext(UsuarioContext);
    
    const [correo, setCorreo] = useState('');
    const onChangeCorreo = (event) => setCorreo(event.target.value);

    const [password, setPassword] = useState('');
    const onChangePassword = (event) => setPassword(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickLogin = () => {
        setLoading(true);
        setError(null);

        Login({
            correo,
            contraseña: password,
        }).then((res) => {

            if(res.error) {
                console.log(res);
                setError(res.error);
            } else {
                console.log('res >>> ', res)
                const { usuario, token, } = res;
                context.setUsuario({
                    ...(usuario || {}),
                    token,
                });
            }
        }).catch(error => {
            setError(error.message);
        });
    };

    if(context.usuario) {
        return (
            <Navigate to='/' />
        );
    }

    return (
        <LoginUI
            correo={correo}
            onChangeCorreo={onChangeCorreo}
            password={password}
            onChangePassword={onChangePassword}
            onClickLogin={onClickLogin}
            isLoading={loading}
            error={error}
        />
    );
};