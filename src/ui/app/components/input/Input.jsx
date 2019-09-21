import React from 'react'

import './input.css'

export default class Input extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            title:'',
            question:'',
            tags:[]
        }
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleSubmit(e) {
        e.preventDefault()
    }
    render() {
        return ( 
            <div className='tin-input'>
                {this.props.children}
                <form onSubmit={this.handleSubmit} className='t-form'>
                    <input type='text' name='title' placeholder='title' className='t-form-element' />
                    <textarea name='question' placeholder='question'  className='t-form-element' />
                    <input type='submit' value='Ask'/>
                </form>
            </div>
        )
    }
}