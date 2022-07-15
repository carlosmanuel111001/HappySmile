export const EspecialistaUI = ({
    especialistas,
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
                        Especialidad
                    </td>
                    <td>
                        Acciones
                    </td>
                </tr>
            </thead>
            <tbody>
                {especialistas && especialistas.length > 0 && especialistas.map(especialista =>
                    <tr key={especialista.especialistaId}>
                        <td>
                            {especialista.nombres}
                        </td>
                        <td>
                            {especialista.apellidos}
                        </td>
                        <td>
                            {especialista.especialidad}
                        </td>
                        <td>
                            {/* <button>
                                Editar
                            </button> */}
                            <button
                                onClick={() => onClickEliminar(especialista.especialistaId)}
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