import { PublicClientApplication, EventType, InteractionType } from "@azure/msal-browser";
import { msalConfig } from "./authConfig";
import { getBaseRouterUrl } from './BaseRouterUrl'

let instance;

export const authInit = (redirectRoute) => {

    const config = { ...msalConfig }
    const baseUrl = getBaseRouterUrl();

    config.auth.redirectUri = `${window.location.origin}${baseUrl}${redirectRoute}`;

    const msalInstance = new PublicClientApplication(config);

    instance = msalInstance;

    return instance

};

const handleRedirection = () => {

    return new Promise((resolve, reject) => {
        

        const success = (payload) => {
            resolve(payload);
            
        }

        const failure = (payload) => {
            reject(payload);
        }

        instance.addEventCallback(message => {
            console.log(message.eventType);
            

            switch (message.eventType) {               
                case EventType.LOGIN_SUCCESS:
                case EventType.ACQUIRE_TOKEN_SUCCESS:
                    if (message.interactionType === InteractionType.Redirect) {

                        const account = message.payload.account;
                        instance.setActiveAccount(account);

                        success(message);
                    }
                    break;                
                case EventType.LOGIN_FAILURE:
                    failure(message);
                    break;                
                default:                   
                    break;
            }
        });
    });
}

export const onAuthenticated = async (state) => {
   


    try {
        var response = await handleRedirection();
        

        return response;
        
    }
    catch (error) {
        console.log(error);
    }
}

export const authenticate = async (state) => {

    try {

        instance.loginRedirect({ state: state });

    }
    catch (error) {
        console.log(error);
    }
}





export const getAccessToken = async (request) => {

    try {      
        try {
            let response = await instance.acquireTokenSilent(request);
            return response.accessToken;
        }
        catch (e) {
            await instance.acquireTokenRedirect(request);
            var response = await handleRedirection();
            return response.accessToken ;
        }
    }
    catch (error) {
        reject(error);
    }

}
