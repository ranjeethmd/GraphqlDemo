export const msalConfig = {
    auth: {
        clientId: "80f88eed-1425-4a57-92d7-ab61b4deac75",
        authority: "https://login.microsoftonline.com/36ae20d2-bdd1-4754-96e3-c88bfa008266", // This is a URL (e.g. https://login.microsoftonline.com/{your tenant ID})
        //redirectUri: window.origin;
        navigateToLoginRequestUrl: false
    },
    cache: {
        cacheLocation: "sessionStorage", // This configures where your cache will be stored
        storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
    }
};

// Add scopes here for ID token to be used at Microsoft identity platform endpoints.
export const loginRequest = {
    scopes: [
        "api://6dab2055-c5ed-4632-8822-d31189a4cac1/Graph.Read",
        "api://6dab2055-c5ed-4632-8822-d31189a4cac1/Graph.Write"
    ]
};