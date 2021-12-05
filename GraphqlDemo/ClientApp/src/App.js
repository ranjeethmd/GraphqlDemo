import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { UpdateData } from './components/UpdateData';
import { useApolloBearer } from './components/UseApolloBearer';

import {
    ApolloClient,
    InMemoryCache,
    ApolloProvider
} from "@apollo/client";


import './custom.css';


export const App = () => {

    const [link] = useApolloBearer(`/graphql`)

    const client = new ApolloClient({       
        link: link,
        cache: new InMemoryCache()        
    });

    return (
        <ApolloProvider client={client}>
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/update-data' component={UpdateData} />
                <Route path='/fetch-data' component={FetchData} />
                <Route exact path='/logout' component={Home} />
            </Layout>
        </ApolloProvider>
    );
}

