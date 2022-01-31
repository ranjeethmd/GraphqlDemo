import { setContext } from '@apollo/client/link/context';
import { loginRequest } from "./authConfig";

import { getAccessToken } from './Authentication'

import {
    ApolloClient,
    InMemoryCache,   
    createHttpLink
} from "@apollo/client";



export const getApolloClient = (url) => {   
    
    const httpLink = createHttpLink({
        uri: url,
    });
    

    const request = {
        ...loginRequest,        
    };
   



    const authLink = setContext(async (_, { headers }) => {

        const token = await getAccessToken(request);

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