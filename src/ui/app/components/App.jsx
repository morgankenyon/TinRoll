import React from 'react'

import Nav from './nav/Nav'
import Landing from './landing/Landing'
import Footer from './footer/Footer'

import Questions from './questions/Questions'
import SingleQuestion from './questions/SingleQuestion'

import { HashRouter as Router, Route } from 'react-router-dom'

import './app.css'

class App extends React.Component {
    render() {
        return (
            <Router>
                <div id='tinApp'>
                    <Nav />


                    <Route exact path='/' component={Landing} />
                    <Route path='/questions' component={Questions} />
                    <Route path={`/question/:titleId`} component={SingleQuestion} />

                    <Footer />
                </div>
            </Router>

        )
    }
}

export default App