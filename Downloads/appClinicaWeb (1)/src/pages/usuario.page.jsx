import { useState } from "react";
import { UsuarioContenedor } from "../contenedores/usuarios";
import { CreateUsuarioContenedor } from "../contenedores/usuarios/create";
import { AppLayout } from "../tema/app-layout";

export const UsuarioPage = () => {
    const [reloadPage, setReloadPage] = useState(true);
    return (
        <AppLayout>
            <section className='section'>
                <h2>Usuario</h2>
                <CreateUsuarioContenedor
                    setReload={setReloadPage}
                />
            </section>

            <section className='section'>
                <h2>Listado de Usuarios</h2>
                <UsuarioContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
        </AppLayout>
    );
};