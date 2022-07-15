import { useState, useEffect, useContext } from 'react';
import { EliminarCita, GetCitas } from '../../api/cita.api';
import { CitaUI } from '../../componentes/cita';
import { UsuarioContext } from './../../contexts/usuario';

export const CitaContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);
    
    const [datos, setDatos] = useState([]);
    useEffect(() => {
        if(reload) {
            GetCitas(usuario.token)
            .then(data => {
                setDatos(data || []);
            })
            .catch(error => console.log(error));
            setReload(false);
        }
    }, [reload]);

    const onClickEliminar = (citaId) => {
        EliminarCita(citaId, usuario.token)
        .then(res => {
            setReload(true);
        })
        .catch(error => {
            console.log(error);
        });
    };

    return (
        <CitaUI
            citas={datos}
            onClickEliminar={onClickEliminar}
        />
    );
};