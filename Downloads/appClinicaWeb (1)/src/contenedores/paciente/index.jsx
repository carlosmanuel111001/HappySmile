import { useState, useEffect, useContext } from 'react';
import { EliminarPaciente, GetPacientes } from '../../api/paciente.api';
import { PacienteUI } from '../../componentes/paciente';
import { UsuarioContext } from '../../contexts/usuario';

export const PacienteContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario } = useContext(UsuarioContext);

    const [datos, setDatos] = useState();
    useEffect(() => {
        if(reload) {
            GetPacientes(usuario.token)
            .then(data => {
                setDatos(data || []);
            })
            .catch(error => console.log(error));
            setReload(false);
        }
        
    }, [reload]);

    const onClickEliminar = (pacienteId) => {
        EliminarPaciente(pacienteId, usuario.token)
        .then(res => {
            setReload(true);
        })
        .catch(error => {
            console.log(error);
        });
    };

    return (
        <PacienteUI
            pacientes={datos}
            onClickEliminar={onClickEliminar}
        />
    );
};