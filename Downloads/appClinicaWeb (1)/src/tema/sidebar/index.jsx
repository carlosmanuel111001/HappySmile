import { useContext } from 'react';
import { UsuarioContext } from '../../contexts/usuario';
import { NavLink } from "react-router-dom";

const isActiveStyles = {
    backgroundColor: 'rgba(0, 0, 0, .3)',
};

export const Sidebar = () => {
    const context = useContext(UsuarioContext);
    const {
        adminRole,
        pacienteRole,
        especialistaRole,
    } = context;

    const logout = () => {
        context.setUsuario(null);
    };
    return (
        <aside>
            <nav>
                <ul>
                    <li className='list-header'>» Funciones</li>
                    <li>
                        <NavLink
                            to='/'
                            style={({ isActive }) => isActive ? isActiveStyles : {}}
                        >
                            Home
                        </NavLink>
                    </li>
                    {adminRole && (
                        <>
                            <li>
                                <NavLink
                                    to='/paciente'
                                    style={({ isActive }) => isActive ? isActiveStyles : {}}
                                >
                                    Pacientes
                                </NavLink>
                            </li>
                            <li>
                                <NavLink
                                    to='/especialista'
                                    style={({ isActive }) => isActive ? isActiveStyles : {}}
                                >
                                    Especialistas
                                </NavLink>
                            </li>
                        </>
                    )}
                    
                    {(pacienteRole || adminRole) && (
                        <li>
                            <NavLink
                                to='/cita'
                                style={({ isActive }) => isActive ? isActiveStyles : {}}
                            >
                                Citas
                            </NavLink>
                        </li>
                    )}

                    {(especialistaRole || adminRole) && (
                        <li>
                            <NavLink
                                to='/diagnostico'
                                style={({ isActive }) => isActive ? isActiveStyles : {}}
                            >
                                Diagnosticos
                            </NavLink>
                        </li>
                    )}
                </ul>
            </nav>

            <nav>
                <ul>
                    <li className='list-header'>» Configuración</li>
                    {adminRole && (
                        <li>
                            <NavLink
                                to='/usuario'
                                style={({ isActive }) => isActive ? isActiveStyles : {}}
                            >
                                Usuarios
                            </NavLink>
                        </li>
                    )}
                    
                    <li>
                        <NavLink
                            to='/cambiarPassword'
                            style={({ isActive }) => isActive ? isActiveStyles : {}}
                        >
                            Cambiar Contraseña
                        </NavLink>
                    </li>
                    <li>
                        <button onClick={logout}>
                            Cerrar Sesion
                        </button>
                    </li>
                </ul>
            </nav>
        </aside>
    );
};