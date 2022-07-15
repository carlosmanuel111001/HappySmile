export const DiagnosticoUI = ({
    diagnosticos,
    onClickEliminar,
}) => {
    return (
        <table>
            <thead>
                <tr>
                    <td>
                        Paciente
                    </td>
                    <td>
                        Especialista
                    </td>
                    <td>
                        Fecha Diagnostico
                    </td>
                    <td>
                        Sintomas
                    </td>
                    <td>
                        Malestar
                    </td>
                    <td>
                        Diagnóstico
                    </td>
                    <td>
                        Acciones
                    </td>
                </tr>
            </thead>
            <tbody>
                {diagnosticos && diagnosticos.length > 0 && diagnosticos.map(diagnostico =>
                    <tr key={`${diagnostico.citaId}-${diagnostico.especialistaId}`}>
                        <td>
                            {diagnostico.cita?.paciente?.nombres} {diagnostico.cita?.paciente?.apellidos}
                        </td>
                        <td>
                            {diagnostico.especialista?.nombres} {diagnostico.especialista?.apellidos}
                        </td>
                        <td>
                            {diagnostico.fechaDiagnostico}
                        </td>
                        <td>
                            {diagnostico.cita?.sintomas}
                        </td>
                        <td>
                            {diagnostico.descripcionMalestar}
                        </td>
                        <td>
                            {diagnostico.descripcionDiagnostico}
                        </td>
                        <td>
                            {/* <button>
                                Editar
                            </button> */}
                            <button onClick={() => onClickEliminar(diagnostico.citaId, diagnostico.especialistaId)}>
                                Eliminar
                            </button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};