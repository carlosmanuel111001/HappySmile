import { useState } from "react";
import { EspecialistaContenedor } from "../contenedores/especialista";
import { CreateEspecialistaContenedor } from "../contenedores/especialista/create";
import { AppLayout } from "../tema/app-layout";

export const EspecialistaPage = () => {
    const [reloadPage, setReloadPage] = useState(true);

    return (
        <AppLayout>
            <section className='section'>
                <h2>Especialista</h2>
                <CreateEspecialistaContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
            <section className='section'>
                <h2>Listado de Especialistas</h2>
                <EspecialistaContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
        </AppLayout>
    );
};