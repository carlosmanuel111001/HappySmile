import { useState, useEffect, useContext } from 'react';
import { EliminarEspecialista, GetEspecialistas } from '../../api/especialista.api';
import { EspecialistaUI } from '../../componentes/especialista';
import { UsuarioContext } from '../../contexts/usuario';

export const EspecialistaContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);
    
    const [especialistas, setEspecialistas] = useState();
    useEffect(() => {
        if(reload) {
            GetEspecialistas(usuario.token)
            .then(data => {
                setEspecialistas(data || []);
            })
            .catch(error => console.log(error));

            setReload(false);
        }
        
    }, [reload]);

    const onClickEliminar = (especialistaId) => {
        EliminarEspecialista(especialistaId, usuario.token)
        .then(res => {
            setReload(true);
        })
        .catch(error => {
            console.log(error);
        });
    };

    return (
        <EspecialistaUI
            especialistas={especialistas}
            onClickEliminar={onClickEliminar}
        />
    );
};