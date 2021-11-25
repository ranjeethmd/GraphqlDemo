import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { UpdateData } from './components/UpdateData';

import './custom.css';


export const App = () => {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/update-data' component={UpdateData} />
            <Route path='/fetch-data' component={FetchData} />
        </Layout>
    );
}

