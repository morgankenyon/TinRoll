import React from 'react'

import Nav from './nav/Nav'
import Landing from './landing/Landing'
import Question from './question/Question'
import SingleQuestion from './question/singleQuestion/SingleQuestion'
import Profile from './profile/Profile'
import Footer from './footer/Footer'

import './app.css'

import { HashRouter as Router, Route } from 'react-router-dom'

class App extends React.Component {
    constructor(props) {
        super(props)

    }

    componentDidMount() {
        console.log('mount app')
    }

    render() {
        return (
            <Router>
                <div className='tin-app'>

                    <Nav />

                    <div className='tin-content'>

                        <Route exact path='/' component={Landing} />
                        <Route exact path='/question' component={Question} />
                        <Route path='/question/:id' component={SingleQuestion} />
                        <Route path='/profile' component={Profile} />

                    </div>

                    <Footer />

                </div>
            </Router>

        )
    }
}

export default App