import React, { Suspense } from 'react';
import { Route } from 'react-router';
import './custom.css';


const Layout = React.lazy(() => import('./components/Layout'));
const Home = React.lazy(() => import('./components/Home'));
const UpdateData = React.lazy(() => import('./components/UpdateData'));
const FetchData = React.lazy(() => import('./components/FetchData'));


export const App = () => {

    return (
        <Suspense fallback={<div>Loading...</div>}>
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/update-data' component={UpdateData} />
                <Route path='/fetch-data' component={FetchData} />
                <Route exact path='/logout' component={Home} />
            </Layout>
        </Suspense>
    );
}

