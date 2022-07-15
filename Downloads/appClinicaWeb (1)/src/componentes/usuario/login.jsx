import { Input } from "../../tema/input";

export const LoginUI = ({
    correo,
    onChangeCorreo,
    password,
    onChangePassword,
    onClickLogin,
    loading,
    error,
}) => {
    return (
        <div className='login-wrapper'>
            <div className='login-form'>
                <h3>😁 <span>Happy</span> Smile</h3>

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

                <button
                    onClick={onClickLogin}
                    disabled={loading}
                >
                    Iniciar Sesion
                </button>

                {error && (
                    <p className='error'>
                        <b>Error: </b>
                        {error}
                    </p>
                )}
            </div>
        </div>
    );
};