import React from 'react'

import { Link } from 'react-router-dom'

import './nav.css'

const Landing = () => {

    return <div id='tinNav'>
        <div id='tinNavLeft'>
            <Link to='/'>TinRoll</Link>
            <Link to='/questions'>Questions</Link>
        </div>
        <div id='tinNavRight'>
            <Link to='/profile'>Profile</Link>
        </div>
    </div>
}

export default Landing