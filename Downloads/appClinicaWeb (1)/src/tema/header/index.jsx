import { useContext } from "react";
import { UsuarioContext } from "../../contexts/usuario";

export const Header = () => {
    const context = useContext(UsuarioContext);
    const { usuario } = context;
    return (
        <header>
            <h3 className="logo">😁 Happy Smile</h3>
            {!!usuario && (
                <p>
                    {usuario.correo}
                </p>
            )}
        </header>
    );
};