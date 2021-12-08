import { setContext } from '@apollo/client/link/context';
import { loginRequest } from "./authConfig";

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
   

    const getAccessToken = async () => {

        await instance.handleRedirectPromise();

        const accounts = instance.getAllAccounts();

        if (accounts.length > 0) {
            instance.setActiveAccount(accounts[0]);
        }

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