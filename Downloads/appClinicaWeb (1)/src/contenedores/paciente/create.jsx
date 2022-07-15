import { useEffect, useState, useContext, } from 'react';
import { CrearPaciente, GetUsuariosPacientes } from '../../api/paciente.api';
import { CreatePacienteUI } from '../../componentes/paciente/create';
import { UsuarioContext } from '../../contexts/usuario';

export const CreatePacienteContenedor = ({
    reload,
    setReload,
}) => {

    const { usuario: usuarioCuenta } = useContext(UsuarioContext);
    
    const [nombres, setNombres] = useState('');
    const onChangeNombres = (event) => setNombres(event.target.value);

    const [apellidos, setApellidos] = useState('');
    const onChangeApellidos = (event) => setApellidos(event.target.value);

    const [sexo, setSexo] = useState('');
    const onChangeSexo = (event) => setSexo(event.target.value);

    const [posiblesUsuarios, setPosiblesUsuarios] = useState([]);
    const [usuario, setUsuario] = useState('');
    const onChangeUsuario = (event) => setUsuario(event.target.value);

    const [fechaNacimiento, setFechaNacimiento] = useState('');
    const onChangeFechaNacimiento = (event) => setFechaNacimiento(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickCrear = () => {
        setLoading(true);
        setError(null);

        CrearPaciente({
            nombres,
            apellidos,
            sexo,
            usuarioId: usuario,
            fechaNacimiento,
            bandera: false,
        }, usuarioCuenta.token).then((res) => {
            setLoading(false);

            // Update List
            setReload(true);
            
            setNombres('');
            setApellidos('');
            setSexo('');
            setUsuario('');
            setFechaNacimiento('');
        }).catch(error => {
            setError(error);
        });
    };

    useEffect(() => {
        if(reload) {
            GetUsuariosPacientes(usuarioCuenta.token)
            .then(usuarios => {
                const usuariosOptions = usuarios?.map(({ usuarioId, correo }) => ({
                    value: usuarioId,
                    text: correo
                }));
                setPosiblesUsuarios(usuariosOptions);
            })
            .catch(error => console.log(error));
        }
    }, [reload]);

    return (
        <CreatePacienteUI
            nombres={nombres}
            onChangeNombres={onChangeNombres}
            apellidos={apellidos}
            onChangeApellidos={onChangeApellidos}
            sexo={sexo}
            onChangeSexo={onChangeSexo}
            usuario={usuario}
            posiblesUsuarios={posiblesUsuarios}
            onChangeUsuario={onChangeUsuario}
            fechaNacimiento={fechaNacimiento}
            onChangeFechaNacimiento={onChangeFechaNacimiento}
            onClickCrear={onClickCrear}
            isLoading={loading}
            error={error}
        />
    );
};