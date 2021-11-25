import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { App } from './App';
import {
    ApolloClient,
    InMemoryCache,
    ApolloProvider
} from "@apollo/client";

import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const client = new ApolloClient({
    uri: `/graphql`,
    cache: new InMemoryCache(),
    //headers: {
    //    Authorization: `bearer ${GITHUB_AUTH_TOKEN}`,
    //},
});

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <ApolloProvider client={client}>
            <App />
        </ApolloProvider>
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

