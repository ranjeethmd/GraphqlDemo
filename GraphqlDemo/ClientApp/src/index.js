import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { App } from './App';

import { getApolloClient } from './getApolloClient'

import registerServiceWorker from './registerServiceWorker';

import { PublicClientApplication } from "@azure/msal-browser";
import { MsalProvider } from "@azure/msal-react";
import { msalConfig } from "./authConfig";

import { ApolloProvider } from "@apollo/client";


const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const msalInstance = new PublicClientApplication(msalConfig);

const client = getApolloClient('/graphql',msalInstance)

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <MsalProvider instance={msalInstance}>
            <ApolloProvider client={client}>
                <App />
            </ApolloProvider>
        </MsalProvider>
    </BrowserRouter>,
    rootElement);

registerServiceWorker();

