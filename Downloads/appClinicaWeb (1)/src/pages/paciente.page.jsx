import { useState } from "react";
import { PacienteContenedor } from "../contenedores/paciente";
import { CreatePacienteContenedor } from "../contenedores/paciente/create";
import { AppLayout } from "../tema/app-layout";

export const PacientePage = () => {
    const [reloadPage, setReloadPage] = useState(true);

    return (
        <AppLayout>
            <section className='section'>
                <h2>Paciente</h2>
                <CreatePacienteContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
            <section className='section'>
                <h2>Paciente</h2>
                <PacienteContenedor
                    reload={reloadPage}
                    setReload={setReloadPage}
                />
            </section>
           
        </AppLayout>
    );
};