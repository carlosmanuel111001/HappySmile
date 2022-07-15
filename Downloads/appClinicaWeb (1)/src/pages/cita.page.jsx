import { useState } from "react";
import { CitaContenedor } from "../contenedores/cita";
import { CreateCitaContenedor } from "../contenedores/cita/create";
import { AppLayout } from "../tema/app-layout";

export const CitaPage = () => {
    const [reloadPage, setReloadPage] = useState(true);

    return (
        <AppLayout>
            <section className='section'>
                <h2>Citas</h2>
                <CreateCitaContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>

            <section className='section'>
                <h2>Listado de Citas</h2>
                <CitaContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
        </AppLayout>
    );
};