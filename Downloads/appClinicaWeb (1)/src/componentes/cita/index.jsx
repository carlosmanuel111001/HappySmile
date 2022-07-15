export const CitaUI = ({
    citas,
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
                        Fecha Registro
                    </td>
                    <td>
                        Fecha Visita
                    </td>
                    <td>
                        Sintomas
                    </td>
                    <td>
                        Acciones
                    </td>
                </tr>
            </thead>
            <tbody>
                {citas && citas.length > 0 && citas.map(cita =>
                    <tr key={cita.citaId}>
                        <td>
                            {cita.paciente?.nombres} {cita.paciente?.apellidos}
                        </td>
                        <td>
                            {cita.fechaRegistro}
                        </td>
                        <td>
                            {cita.fechaVisita}
                        </td>
                        <td>
                            {cita.sintomas}
                        </td>
                        <td>
                            {/* <button>
                                Editar
                            </button> */}
                            <button onClick={() => onClickEliminar(cita.citaId)}>
                                Eliminar
                            </button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};