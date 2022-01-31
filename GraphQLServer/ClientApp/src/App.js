import React from 'react';
import { Route, Redirect} from 'react-router';
import './custom.css';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { UpdateData } from './components/UpdateData';
import { FetchData } from './components/FetchData';
import { SignIn } from './components/SignIn';


export const App = () => {
    

    return (
        <Layout>               
                <Route path='/update-data' component={UpdateData} />
                <Route path='/fetch-data' component={FetchData} />
                <Route path='/logout' component={Home} />
                 <Route path='/home' component={Home} />
                <Route  path='/signin' component={SignIn} />
                <Route exact path='/' >
                    <Redirect to="/home" />
                </Route>
        </Layout>       
    );
}

