import React from 'react'
import '@babel/polyfill'

import './single.css'

import { getObjectData } from '../../../utils/apiCalls'

export default class SingleQuestion extends React.Component {
    constructor(props) {
        super(props) 

        this.state = {
            question:{}
        }

        this.getQuestion = this.getQuestion.bind(this)
    }

    componentDidMount() {
        console.log('mount single')
        let paramsId = this.props.match.params.id
        let intId = parseInt(paramsId, 10)
        this.getQuestion(intId)
    }

    async getQuestion(id) {
        let question = await getObjectData(`http://localhost:1076/api/questions/${id}`)
        this.setState({question:question.data})
    }

    componentDidUpdate() {
        console.log('update single')
    }

    componentWillUnmount() {
        console.log('unmount single')
    }

    render() {
        return (
            <div className='t-single-question'>
                {
                    this.state.question.id <= 0 &&
                    <h2>Loading...</h2>
                }
                {
                    this.state.question.id > 0 &&
                    <div className='t-s-q-question'>
                        <h2>{this.state.question.title}</h2>
                        <p>{this.state.question.createdDate}</p>
                        <p id='t-single-p'>{this.state.question.content}</p>
                    </div>
                    

                }
            </div>
        )
    }
}