import React  from "react";
import { useHistory, useLocation } from 'react-router-dom';


/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = () => {
    const history = useHistory();
    const location = useLocation();


    const handleLogin = () => {
        history.push(`/signin?redirect=${location.pathname}`);
    }

    return (
        <button className="btn btn-primary"  onClick={() => handleLogin()}>Sign in</button>
    );
}