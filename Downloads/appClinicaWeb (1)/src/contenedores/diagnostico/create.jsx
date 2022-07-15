import { useEffect, useState, useContext, } from 'react';
import { GetCitas } from '../../api/cita.api';
import { GetEspecialistas } from '../../api/especialista.api';
import { CreateDiagnosticoUI } from '../../componentes/diagnostico/create';
import { CrearDiagnostico } from '../../api/diagnostico.api';
import { UsuarioContext } from '../../contexts/usuario';

export const CreateDiagnosticoContenedor = ({
    reload,
    setReload,
}) => {
    const {
        usuario,
        adminRole,
        especialistaRole,
    } = useContext(UsuarioContext);

    const [citas, setCitas] = useState([]);
    const [cita, setCita] = useState('');
    const onChangeCita = (event) => setCita(event.target.value);

    let especialistaByDefault = '';
    if(!adminRole && especialistaRole) {
        especialistaByDefault = usuario.Especialista?.especialistaId;
    }

    const [especialistas, setEspecialistas] = useState([]);
    const [especialista, setEspecialista] = useState(especialistaByDefault);
    const onChangeEspecialista = (event) => setEspecialista(event.target.value);

    const [descripcionMalestar, setMalestar] = useState('');
    const onChangeMalestar = (event) => setMalestar(event.target.value);

    const [descripcionDiagnostico, setDiagnostico] = useState('');
    const onChangeDiagnostico = (event) => setDiagnostico(event.target.value);

    const [estado, setEstado] = useState('');
    const onChangeEstado = (event) => setEstado(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickCrear = () => {
        setLoading(true);
        setError(null);

        CrearDiagnostico({
            especialistaId: especialista,
            citaId: cita,
            descripcionMalestar,
            descripcionDiagnostico,
            estadoDiagnostico: estado,
        }, usuario.token).then((res) => {
            setLoading(false);

            // Update List
            setReload(true);
            
            setCita('');
            setEspecialista('');
            setMalestar('');
            setDiagnostico('');
            setEstado('');
        }).catch(error => {
            setError(error);
        });
    };

    useEffect(() => {
        if(reload) {
            GetCitas(usuario.token)
            .then(citas => {
                const citasOptions = citas?.map(({ citaId, paciente, sintomas }) => ({
                    value: citaId,
                    text: `${paciente?.nombres} ${paciente?.apellidos} - ${sintomas}`,
                }));
                setCitas(citasOptions);
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
        <CreateDiagnosticoUI
            cita={cita}
            citas={citas}
            onChangeCita={onChangeCita}
            especialista={especialista}
            especialistas={especialistas}
            onChangeEspecialista={onChangeEspecialista}
            especialistaDisable={!adminRole && especialistaRole}
            descripcionMalestar={descripcionMalestar}
            onChangeMalestar={onChangeMalestar}
            descripcionDiagnostico={descripcionDiagnostico}
            onChangeDiagnostico={onChangeDiagnostico}
            estado={estado}
            onChangeEstado={onChangeEstado}
            onClickCrear={onClickCrear}
            isLoading={loading}
            error={error}
        />
    );
};