import { NavLink } from "react-router-dom";

export const Footer = () => {
    return (
        <footer>
            <p>
                © <NavLink to='/'>Happy Smile</NavLink> 2021. All Rights Reserved
            </p>
        </footer>
    );
};