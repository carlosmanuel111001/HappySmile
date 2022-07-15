import { Footer } from "../footer";
import { Header } from "../header";

import './../../assets/layout.css';

export const Layout = ({ children }) => {
    return (
        <>
            <Header />
                <main>
                    {children}
                </main>
            <Footer />
        </>
    );
};