import { useEffect, useState, useContext, } from 'react';
import { CrearEspecialista, GetUsuariosEspecialistas } from '../../api/especialista.api';
import { CreateEspecialistaUI } from '../../componentes/especialista/create';
import { UsuarioContext } from '../../contexts/usuario';

export const CreateEspecialistaContenedor = ({
    reload,
    setReload,
}) => {
    const { usuario: usuarioCuenta } = useContext(UsuarioContext);
    
    const [nombres, setNombres] = useState('');
    const onChangeNombres = (event) => setNombres(event.target.value);

    const [apellidos, setApellidos] = useState('');
    const onChangeApellidos = (event) => setApellidos(event.target.value);

    const [posiblesUsuarios, setPosiblesUsuarios] = useState([]);
    const [usuario, setUsuario] = useState('');
    const onChangeUsuario = (event) => setUsuario(event.target.value);

    const [especialidad, setEspecialidad] = useState('');
    const onChangeEspecialidad = (event) => setEspecialidad(event.target.value);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const onClickCrear = () => {
        setLoading(true);
        setError(null);

        CrearEspecialista({
            nombres,
            apellidos,
            usuarioId: usuario,
            especialidad,
            bandera: false,
        }, usuarioCuenta.token).then((res) => {
            setLoading(false);

            // Update List
            setReload(true);
            
            setNombres('');
            setApellidos('');
            setUsuario('');
            setEspecialidad('');
        }).catch(error => {
            setError(error);
        });
    };

    useEffect(() => {
        if(reload) {
            GetUsuariosEspecialistas(usuarioCuenta.token)
            .then(usuarios => {
                console.log(usuarios);
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
        <CreateEspecialistaUI
            nombres={nombres}
            onChangeNombres={onChangeNombres}
            apellidos={apellidos}
            onChangeApellidos={onChangeApellidos}
            usuario={usuario}
            posiblesUsuarios={posiblesUsuarios}
            onChangeUsuario={onChangeUsuario}
            especialidad={especialidad}
            onChangeEspecialidad={onChangeEspecialidad}
            onClickCrear={onClickCrear}
            isLoading={loading}
            error={error}
        />
    );
};