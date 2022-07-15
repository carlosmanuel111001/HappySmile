export const PacienteUI = ({
    pacientes,
    onClickEliminar,
}) => {
    return (
        <table>
            <thead>
                <tr>
                    <td>
                        Nombres
                    </td>
                    <td>
                        Apellidos
                    </td>
                    <td>
                        Sexo
                    </td>
                    <td>
                        Fecha Nacimiento
                    </td>
                    <td>
                        Acciones
                    </td>
                </tr>
            </thead>
            <tbody>
                {pacientes && pacientes.length > 0 && pacientes.map(paciente =>
                    <tr key={paciente.pacienteId}>
                        <td>
                            {paciente.nombres}
                        </td>
                        <td>
                            {paciente.apellidos}
                        </td>
                        <td>
                            {paciente.sexo}
                        </td>
                        <td>
                            {paciente.fechaNacimiento}
                        </td>
                        <td>
                            {/* <button>
                                Editar
                            </button> */}
                            <button
                                onClick={() => onClickEliminar(paciente.pacienteId)}
                            >
                                Eliminar
                            </button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};