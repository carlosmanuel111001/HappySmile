export const UsuarioUI = ({
    usuarios,
    onClickEliminar,
}) => {
    return (
        <table>
            <thead>
                <tr>
                    <td>
                        Correo
                    </td>
                    <td>
                        Acciones
                    </td>
                </tr>
            </thead>
            <tbody>
                {usuarios && usuarios.length > 0 && usuarios.map(usuario =>
                    <tr key={usuario.usuarioId}>
                        <td>
                            {usuario.correo}
                        </td>
                        
                        <td>
                            {/* <button>
                                Editar
                            </button> */}
                            <button onClick={() => onClickEliminar(usuario.usuarioId)}>
                                Eliminar
                            </button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};