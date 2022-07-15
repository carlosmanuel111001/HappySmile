import { Input } from "../../tema/input";

export const CreateCitaUI = ({
    paciente,
    pacientes,
    onChangePaciente,
    pacienteDisable,
    especialista,
    especialistas,
    onChangeEspecialista,
    fechaVisita,
    onChangeFechaVisita,
    sintomas,
    onChangeSintomas,
    onClickCrear,
    loading,
    error,
}) => {
    return (
        <div className='form'>
            <div className='grid'>
                <Input
                    id='paciente-input'
                    label='Pacientes'
                    options={pacientes}
                    value={paciente}
                    onChange={onChangePaciente}
                    inputProps={{
                        disabled: loading || pacienteDisable,
                    }}
                />

                <Input
                    id='especialista-input'
                    label='Especialistas'
                    options={especialistas}
                    value={especialista}
                    onChange={onChangeEspecialista}
                    inputProps={{
                        disabled: loading,
                    }}
                />

                <Input
                    id='fecha-input'
                    label='Fecha visita'
                    value={fechaVisita}
                    onChange={onChangeFechaVisita}
                    placeholder='Ingrese su fecha de visita'
                    inputProps={{
                        disabled: loading,
                        type: 'date',
                    }}
                />

                <Input
                    id='sintomas-input'
                    label='Síntomas'
                    value={sintomas}
                    onChange={onChangeSintomas}
                    placeholder='Ingrese sus síntomas'
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