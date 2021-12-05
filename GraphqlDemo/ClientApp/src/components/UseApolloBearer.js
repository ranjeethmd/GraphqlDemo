import { createHttpLink } from "@apollo/client";
import { setContext } from '@apollo/client/link/context';
import { loginRequest } from "../authConfig";
import { useMsal } from "@azure/msal-react";



export const useApolloBearer = (url) => {
    const { instance, accounts } = useMsal();

    const httpLink = createHttpLink({
        uri: url,
    });

    const request = {
        ...loginRequest,
        account: accounts[0]
    };

    const getAccessToken = async () => {
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

    return [authLink.concat(httpLink)];
}