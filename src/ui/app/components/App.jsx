import React from 'react'

import Nav from './nav/Nav'
import Landing from './landing/Landing'

import Hello from './random/Hello'

import { HashRouter as Router, Route } from 'react-router-dom'

import './app.css'

class App extends React.Component {
    render() {
        return (
            <Router>
                <div id='tinApp'>
                    <Nav/>


                    <Route exact path='/' component={Landing} />
                    <Route path='/hello' component={Hello} />
                </div>
            </Router>

        )
    }
}

export default App