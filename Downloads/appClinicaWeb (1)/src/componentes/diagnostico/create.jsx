import { Input } from "../../tema/input";

export const CreateDiagnosticoUI = ({
    cita,
    citas,
    onChangeCita,
    especialista,
    especialistas,
    onChangeEspecialista,
    especialistaDisable,
    descripcionMalestar,
    onChangeMalestar,
    descripcionDiagnostico,
    onChangeDiagnostico,
    estado,
    onChangeEstado,
    onClickCrear,
    loading,
    error,
}) => {
    return (
        <div className='form'>
            <div className='grid'>
                <Input
                    id='cita-input'
                    label='Citas'
                    options={citas}
                    value={cita}
                    onChange={onChangeCita}
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='especialista-input'
                    label='Especialistas'
                    options={especialistas}
                    value={especialista}
                    onChange={onChangeEspecialista}
                    inputProps={{
                        disabled: loading || especialistaDisable,
                    }}
                />

                <Input
                    id='malestar-input'
                    label='Malestar'
                    value={descripcionMalestar}
                    onChange={onChangeMalestar}
                    placeholder='Ingrese el malestar'
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='diagnostico-input'
                    label='Diagnóstico'
                    value={descripcionDiagnostico}
                    onChange={onChangeDiagnostico}
                    placeholder='Ingrese su diagnóstico'
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='estado-input'
                    label='Estado'
                    options={[
                        { value: false, text: 'No ha sido posible curar', },
                        { value: true, text: 'Paciente curado', },
                    ]}
                    value={estado}
                    onChange={onChangeEstado}
                    placeholder='Ingrese el estado del paciente'
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