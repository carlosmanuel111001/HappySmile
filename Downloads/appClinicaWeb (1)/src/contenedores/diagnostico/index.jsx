import { useState, useEffect, useContext, } from 'react';
import { EliminarDiagnostico, GetDiagnosticos } from '../../api/diagnostico.api';
import { DiagnosticoUI } from '../../componentes/diagnostico';
import { UsuarioContext } from '../../contexts/usuario';

export const DiagnosticoContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);
    
    const [datos, setDatos] = useState([]);
    useEffect(() => {
        if(reload) {
            GetDiagnosticos(usuario.token)
            .then(data => {
                setDatos(data || []);
            })
            .catch(error => console.log(error));
            setReload(false);
        }
    }, [reload]);

    const onClickEliminar = (citaId, especialistaId) => {
        EliminarDiagnostico(citaId, especialistaId, usuario.token)
        .then(res => {
            setReload(true);
        })
        .catch(error => {
            console.log(error);
        });
    };

    return (
        <DiagnosticoUI
            diagnosticos={datos}
            onClickEliminar={onClickEliminar}
        />
    );
};