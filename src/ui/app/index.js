import ReactDOM from 'react-dom'
import React from 'react'
import App from './components/App'
import './index.css'

global._babelPolyfill = false 

ReactDOM.render(
    <App />,
    document.getElementById('app')
)