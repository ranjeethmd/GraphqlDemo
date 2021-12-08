import { setContext } from '@apollo/client/link/context';
import { loginRequest } from "./authConfig";
import { EventType } from '@azure/msal-browser';

import {
    ApolloClient,
    InMemoryCache,   
    createHttpLink
} from "@apollo/client";



export const getApolloClient = (url, instance) => {   
    
    const httpLink = createHttpLink({
        uri: url,
    });

    const accounts = instance.getAllAccounts();

    const request = {
        ...loginRequest,
        account: accounts[0]
    };


    if (accounts.length > 0) {
        instance.setActiveAccount(accounts[0]);
    }

    instance.addEventCallback((event) => {
        if (event.eventType === EventType.LOGIN_SUCCESS && event.payload.account) {
            const account = event.payload.account;
            instance.setActiveAccount(account);
        }
    }, error => {
        console.log('error', error);
    });


    const getAccessToken = async () => {

        await instance.handleRedirectPromise();

        try {
            let response = await instance.acquireTokenSilent(request);
            return response.accessToken
        }
        catch (e) {
            let response = await instance.acquireTokenRedirect(request);            
            return response.accessToken
        }
    }


    const authLink = setContext(async (_, { headers }) => {

        const token = await getAccessToken();

        return {
            headers: {
                ...headers,
                authorization:`Bearer ${token}`,
            }
        }
    });

    return new ApolloClient({
        link: authLink.concat(httpLink),
        cache: new InMemoryCache()
    });
}