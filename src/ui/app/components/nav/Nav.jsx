import React from 'react'

import './nav.css'

import { Link } from 'react-router-dom'

const Nav = () => {
    return (
        <div className='tin-nav'>
            
            <div className='tin-nav-part'>
                <Link to='/'>Home</Link>
                <Link to='/question'>Question</Link>
            </div>

            <div className='tin-nav-part'>
                <Link to='/profile'>Profile</Link>
            </div>
        </div>
    )
}

export default Nav