import React from 'react'

import './input.css'

import { postObjectData } from '../../utils/apiCalls'

export default class Input extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            title:'Second Question',
            content:'We are trying to make this work',
            tags:[]
        }
        this.handleSubmit = this.handleSubmit.bind(this)
        this.handleChange = this.handleChange.bind(this)
    }

    async handleSubmit(e) {
        e.preventDefault()
        let data = {
            Title:this.state.title,
            Content:this.state.content,
            UserId:1
        }
        console.log(data)
        let status = await postObjectData('http://localhost:1076/api/questions', data)
        console.log(status) 
    }

    handleChange(e) {
        let target = e.target.name
        this.setState({
            [target]:e.target.value
        })

    }
    render() {
        return ( 
            <div className='tin-input'>
                {this.props.children}
                <form onSubmit={this.handleSubmit} className='t-form'>
                    <input 
                        type='text' 
                        name='title' 
                        placeholder='title' 
                        className='t-form-element' 
                        value={this.state.title} 
                        onChange={this.handleChange} 
                    />
                    <textarea 
                        name='content' 
                        placeholder='question'  
                        className='t-form-element' 
                        value={this.state.content} 
                        onChange={this.handleChange} 
                    />
                    <input type='submit' value='Ask'/>
                </form>
            </div>
        )
    }
}