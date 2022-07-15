import { useState } from "react";
import { DiagnosticoContenedor } from "../contenedores/diagnostico";
import { CreateDiagnosticoContenedor } from "../contenedores/diagnostico/create";
import { AppLayout } from "../tema/app-layout";

export const DiagnosticoPage = () => {
    const [reloadPage, setReloadPage] = useState(true);

    return (
        <AppLayout>
            <section className='section'>
                <h2>Diagnóstico</h2>
                <CreateDiagnosticoContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>

            <section className='section'>
                <h2>Listado de Diagnosticos</h2>
                <DiagnosticoContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
        </AppLayout>
    );
};