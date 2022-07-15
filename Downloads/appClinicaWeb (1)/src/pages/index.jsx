import { useContext } from 'react';
import { UsuarioContext } from './../contexts/usuario';
import { AppLayout } from "../tema/app-layout";

export const Home = () => {
    const context = useContext(UsuarioContext);
    const { usuario } = context;
    return (
        <AppLayout>
            <h1>
                Bienvenido
                {usuario && (
                    <span>, {usuario.correo}</span>
                )}
            </h1>
        </AppLayout>
    );
};