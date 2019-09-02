import React from 'react'

import { getQuestionDummy } from '../../utils/apiCalls'

import './question.css'

class SingleQuestion extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            message: 'Loading',
            question:{}
        }

        this.getQuestion = this.getQuestion.bind(this)
    }

    componentDidMount() {
        console.log('mounted')
        this.getQuestion()
    }

    async getQuestion() {
        let paramId = this.props.match.params.titleId
        let response = await getQuestionDummy(paramId)
        console.log(response)
        if(response !== undefined) {
            this.setState({message:'', question:response})
        } else {
            this.setState({message:'Cannot find question', question:{}})
        }
    }
    render() {
        return (
            <div id='tinSingleQuestion'>
                {
                    this.state.message !== '' &&
                    <p>{this.state.message}</p>
                }

                {
                    this.state.question.Title &&
                    <div id='tinQuestionSingle'>
                        <h3>{this.state.question.Title}</h3>
                        <p>{this.state.question.Content}</p>
                    </div>
                } 
            </div>
        )
    }
}

export default SingleQuestion