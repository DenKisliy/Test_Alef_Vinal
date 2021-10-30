import React, { Component } from 'react';
import { Route } from 'react-router';
import { CreateForm } from './components/CreateForm';
import { UpdateForm } from './components/UpdateForm';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route path='/' component={Home} />
                <Route path='/update-form' component={UpdateForm} />
                <Route path='/create-form' component={CreateForm} />
            </Layout>
        );
    }
}
