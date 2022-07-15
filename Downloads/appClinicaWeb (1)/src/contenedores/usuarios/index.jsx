import { useState, useEffect, useContext, } from 'react';
import { EliminarUsuario, GetUsuarios } from '../../api/usuario.api';
import { UsuarioUI } from '../../componentes/usuario';
import { UsuarioContext } from '../../contexts/usuario';

export const UsuarioContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);

    // const [loading, setLoading] = useState(true);
    const [datos, setDatos] = useState();

    useEffect(() => {
        if(reload) {
            GetUsuarios(usuario.token)
            .then(data => {
                setDatos(data || []);
            })
            .catch(error => console.log(error));
            setReload(false);
        }
    }, [reload]);

    const onClickEliminar = (usuarioId) => {
        EliminarUsuario(usuarioId, usuario.token)
        .then(res => {
            setReload(true);
        })
        .catch(error => {
            console.log(error);
        });
    };

    return (
        <UsuarioUI
            usuarios={datos}
            onClickEliminar={onClickEliminar}
        />
    );
};