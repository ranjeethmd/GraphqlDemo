import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { App } from './App';
import { authInit } from './Authentication'
import { getApolloClient } from './getApolloClient'
import { initBaseRouterUrls } from './BaseRouterUrl'
import registerServiceWorker from './registerServiceWorker';
import { MsalProvider } from "@azure/msal-react";
import { ApolloProvider } from "@apollo/client";

const rootElement = document.getElementById('root');
const client = getApolloClient(`${process.env.PUBLIC_URL}/graphql`);
const routerBase = initBaseRouterUrls(`${process.env.MUI_PATHS}`);
const instance = authInit('signin')

ReactDOM.render(
    <BrowserRouter basename={routerBase}>
        <MsalProvider instance={instance}>
            <ApolloProvider client={client}>
                <App />
            </ApolloProvider>
        </MsalProvider>
    </BrowserRouter>,
    rootElement);

registerServiceWorker();

