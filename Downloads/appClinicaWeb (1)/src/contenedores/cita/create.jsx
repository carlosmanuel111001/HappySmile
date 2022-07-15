import { useEffect, useState, useContext, } from 'react';
import { GetPacientes } from '../../api/paciente.api';
import { GetEspecialistas } from '../../api/especialista.api';
import { CreateCitaUI } from '../../componentes/cita/create';
import { CrearCita } from '../../api/cita.api';
import { UsuarioContext } from '../../contexts/usuario';

export const CreateCitaContenedor = ({
    reload,
    setReload,
}) => {
    const {
        usuario,
        adminRole,
        pacienteRole,
    } = useContext(UsuarioContext);

    let pacienteByDefault = '';
    if(!adminRole && pacienteRole) {
        pacienteByDefault = usuario.Paciente?.pacienteId;
    }

    const [pacientes, setPacientes] = useState([]);
    const [paciente, setPaciente] = useState(pacienteByDefault);
    const onChangePaciente = (event) => setPaciente(event.target.value);

    const [especialistas, setEspecialistas] = useState([]);
    const [especialista, setEspecialista] = useState('');
    const onChangeEspecialista = (event) => setEspecialista(event.target.value);

    const [fechaVisita, setFechaVisita] = useState('');
    const onChangeFechaVisita = (event) => setFechaVisita(event.target.value);

    const [sintomas, setSintomas] = useState('');
    const onChangeSintomas = (event) => setSintomas(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickCrear = () => {
        setLoading(true);
        setError(null);

        CrearCita({
            fechaVisita,
            pacienteId: paciente,
            especialistaId: especialista,
            sintomas,
        }, usuario.token).then((res) => {
            setLoading(false);

            // Update List
            setReload(true);
            
            setPaciente('');
            setEspecialista('');
            setFechaVisita('');
            setSintomas('');
        }).catch(error => {
            setError(error);
        });
    };

    useEffect(() => {
        if(reload) {
            GetPacientes(usuario.token)
            .then(pacientes => {
                const pacientesOptions = pacientes?.map(({ pacienteId, nombres, apellidos, }) => ({
                    value: pacienteId,
                    text: `${nombres} ${apellidos}`,
                }));
                setPacientes(pacientesOptions);
            })
            .catch(error => console.log(error));

            GetEspecialistas(usuario.token)
            .then(especialistas => {
                const especialistasOptions = especialistas?.map(({ especialistaId, nombres, apellidos, }) => ({
                    value: especialistaId,
                    text: `${nombres} ${apellidos}`,
                }));
                setEspecialistas(especialistasOptions);
            })
            .catch(error => console.log(error));
        }
    }, [reload]);

    return (
        <CreateCitaUI
            paciente={paciente}
            pacientes={pacientes}
            onChangePaciente={onChangePaciente}
            pacienteDisable={!adminRole && pacienteRole}
            especialista={especialista}
            especialistas={especialistas}
            onChangeEspecialista={onChangeEspecialista}
            fechaVisita={fechaVisita}
            onChangeFechaVisita={onChangeFechaVisita}
            sintomas={sintomas}
            onChangeSintomas={onChangeSintomas}
            onClickCrear={onClickCrear}
            isLoading={loading}
            error={error}
        />
    );
};