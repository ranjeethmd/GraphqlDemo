import React from "react";
import { useMsal } from "@azure/msal-react";


/**
 * Renders a button which, when selected, will redirect the page to the logout prompt
 */
export const SignOutButton = () => {
    const { accounts, instance } = useMsal();

    const handleLogout = (instance) => {

        const logoutRequest = {
            account: accounts[0],
            postLogoutRedirectUri: "/logout"
        }

        instance.logoutRedirect(logoutRequest).catch(e => {
            console.error(e);
        });
    }



    return (
        <button className="btn btn-primary" onClick={() => handleLogout(instance)}>Sign out using Redirect</button>
    );
}