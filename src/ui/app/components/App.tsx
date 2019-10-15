import React from 'react'

import Nav from './nav/Nav'
import Landing from './landing/Landing'
import Question from './question/Question'
import SingleQuestion from './question/singleQuestion/SingleQuestion'
import Profile from './profile/Profile'
import Footer from './footer/Footer'
import Container from '@material-ui/core/Container';

import './app.css'

import { HashRouter as Router, Route } from 'react-router-dom'

const App: React.FC = () => {
    return (
        <Container maxWidth="md">
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
        </Container>
    );
}

export default App;