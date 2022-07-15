import { Input } from "../../tema/input";

export const CreatePacienteUI = ({
    nombres,
    onChangeNombres,
    apellidos,
    onChangeApellidos,
    sexo,
    onChangeSexo,
    fechaNacimiento,
    onChangeFechaNacimiento,
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
                    id='sexo-input'
                    label='Sexo'
                    options={[
                        {value: "M", text: "MASCULINO"},
                        {value: "F", text: "FEMENINO"},
                    ]}
                    value={sexo}
                    onChange={onChangeSexo}
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
                    id='fecha-input'
                    label='Fecha nacimiento'
                    value={fechaNacimiento}
                    onChange={onChangeFechaNacimiento}
                    placeholder='Ingrese su fecha de nacimiento'
                    inputProps={{
                        disabled: loading,
                        type: 'date',
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