import { createContext, useState, } from 'react';

export const UsuarioContext = createContext({});

export const UsuarioContextWrapper = ({ children }) => {
    const [usuario, setUsuario] = useState(null);

    let adminRole = false,
        pacienteRole = false,
        especialistaRole = false;

    if(usuario) {
        adminRole = usuario.bandera;

        if(!adminRole) {
            if(!!usuario.Paciente)
                pacienteRole = true;
            if(!!usuario.Especialista)
                especialistaRole = true;
        }
    }

    return (
        <UsuarioContext.Provider
            value={{
                usuario,
                setUsuario,
                adminRole,
                pacienteRole,
                especialistaRole,
            }}
        >
            {children}
        </UsuarioContext.Provider>
    );
};