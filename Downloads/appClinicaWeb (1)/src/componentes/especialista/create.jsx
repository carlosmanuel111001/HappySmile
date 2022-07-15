import { Input } from "../../tema/input";

export const CreateEspecialistaUI = ({
    nombres,
    onChangeNombres,
    apellidos,
    onChangeApellidos,
    especialidad,
    onChangeEspecialidad,
    usuario,
    posiblesUsuarios,
    onChangeUsuario,
    onClickCrear,
    loading,
    error,
}) => {
    return (
        <div className='form'>
            <div className='grid'>
                <Input
                    id='nombres-input'
                    label='Nombres del paciente'
                    value={nombres}
                    onChange={onChangeNombres}
                    placeholder='Ingrese su nombres'
                    inputProps={{disabled: loading}}
                />

                <Input
                    id='apellidos-input'
                    label='Apellidos del paciente'
                    value={apellidos}
                    onChange={onChangeApellidos}
                    placeholder='Ingrese su apellido'
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='usuario-input'
                    label='Usuarios posibles'
                    options={posiblesUsuarios}
                    value={usuario}
                    onChange={onChangeUsuario}
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='especialidad-input'
                    label='Especialidad'
                    value={especialidad}
                    onChange={onChangeEspecialidad}
                    placeholder='Ingrese su especialidad'
                    inputProps={{
                        disabled: loading,
                    }}
                />
            </div>

            <button
                onClick={onClickCrear}
                disabled={loading}
            >
                {loading ? (
                    'Guardando...'
                ) : (
                    'Guardar Cambios'
                )}
            </button>

            {error && (
                <p className='error'>
                    <b>Error: </b>
                    {error}
                </p>
            )}
        </div>
    );
};