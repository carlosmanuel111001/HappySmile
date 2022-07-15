import { useState, useContext, } from 'react';
import { CrearUsuario } from '../../api/usuario.api';
import { CreateUsuarioUI } from '../../componentes/usuario/create';
import { UsuarioContext } from '../../contexts/usuario';

export const CreateUsuarioContenedor = ({
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);
    
    const [correo, setCorreo] = useState('');
    const onChangeCorreo = (event) => setCorreo(event.target.value);

    const [password, setPassword] = useState('');
    const onChangePassword = (event) => setPassword(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickCrear = () => {
        setLoading(true);
        setError(null);

        CrearUsuario({
            correo,
            contraseña: password,
            bandera: false,
        }, usuario.token).then((res) => {
            setLoading(false);

            // Update List
            setReload(true);
            
            setCorreo('');
            setPassword('');
        }).catch(error => {
            setError(error);
        });
    };

    return (
        <CreateUsuarioUI
            correo={correo}
            onChangeCorreo={onChangeCorreo}
            password={password}
            onChangePassword={onChangePassword}
            onClickCrear={onClickCrear}
            isLoading={loading}
            error={error}
        />
    );
};