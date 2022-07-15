import { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import { UsuarioContext } from '../../contexts/usuario';
import { Layout } from "../layout";
import { Sidebar } from "../sidebar";

export const AppLayout = ({ children }) => {
    const context = useContext(UsuarioContext);
    if(!context.usuario) {
        return <Navigate to='/login' />
    }
    return (
        <Layout>
            <Sidebar />
            <div className='container'>
                {children}
            </div>
        </Layout>
    );
};