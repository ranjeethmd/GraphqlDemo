import React, { useEffect } from 'react'
import { authenticate, onAuthenticated } from "../Authentication";
import { useLocation, useHistory } from "react-router-dom";



export const SignIn = () => {
    const search = useLocation().search;
    const history = useHistory();

    useEffect(() => {
        handleAuthentication();
        
    });

    const handleAuthentication = async () => {
        const params = new URLSearchParams(search);

        const prevUrl = params.get("redirect");

        if (prevUrl) {
            authenticate(prevUrl);
        }
        else {
            const response = await onAuthenticated();
            history.push(response.payload.state);
            console.log(response);
        }
    }

    return (null);
}
    

