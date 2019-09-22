import React from 'react'
import '@babel/polyfill'

import Input from '../input/Input'
import './question.css'

import { getArrayData } from '../../utils/apiCalls' 
import { Link, Route } from 'react-router-dom'

export default class Question extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            questions:[]
        }

        this.getQuestions = this.getQuestions.bind(this)
    }

    componentDidMount() {
        console.log('mount question')
        this.getQuestions()
        
    }

    async getQuestions() {
        let questions = await getArrayData('http://localhost:1076/api/questions')
        this.setState({
            questions
        })
    }

    componentDidUpdate() {
        console.log('update question')
    }

    componentWillUnmount() {
        console.log('unmount question')
    }

    render() {
        return (
            <div className='t-question'>
                
                <div className='t-q-discover'>
                    <h2>Discover</h2>
                    <div className='t-q-d-questions'>
                        {
                            this.state.questions.length > 0 &&
                            this.state.questions.map(question => {
                                return (
                                    <Link to={'/question/' + question.id} key={question.id}>{question.title}</Link>
                                )
                            })
                        }
                    </div>
                </div>
                <div className='t-q-ask'>
                    <Input>
                        <h2>Ask</h2>
                    </Input>
                </div>
            
            </div>
        )
    }
}