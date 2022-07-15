import { Input } from "../../tema/input";

export const CreateUsuarioUI = ({
    correo,
    onChangeCorreo,
    password,
    onChangePassword,
    onClickCrear,
    loading,
    error,
}) => {
    return (
        <div className='form'>
            <div className='grid'>
                <Input
                    id='correo-input'
                    label='Correo del usuario'
                    value={correo}
                    onChange={onChangeCorreo}
                    placeholder='Ingrese su correo'
                    inputProps={{disabled: loading}}
                />

                <Input
                    id='password-input'
                    label='Contraseña'
                    value={password}
                    onChange={onChangePassword}
                    placeholder='Ingrese su contraseña'
                    inputProps={{
                        disabled: loading,
                        type: 'password',
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
                <p>
                    <b>Error: </b>
                    {error?.message}
                </p>
            )}
        </div>
    );
};